using DataAccess.User;
using System.Text.RegularExpressions;

namespace BusinessLogic.User
{
    public class UserService
    {
        private static string _passwordPattern = @"^(?=.*[0-9])(?=.*[a-zæøå])(.{8,})$";
        private static Regex _passwordValidator = new Regex(_passwordPattern, RegexOptions.IgnoreCase);

        private readonly IUserRegistrationRepository _userRegistrationRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRegistrationRepository repository, IUserRepository userRepository)
        {
            _userRegistrationRepository = repository;
            _userRepository = userRepository;
        }

        public string CreateUserRegistration(string emailAddress, string password, string? firstName, string? lastName)
        {
            // Validate email
            if (string.IsNullOrEmpty(emailAddress) || emailAddress.Length > 320 || !emailAddress.Contains('@', StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"'{nameof(emailAddress)}' is not valid.", nameof(emailAddress));
            }

            // Validate password
            if (!_passwordValidator.IsMatch(password))
            {
                throw new ArgumentException($"'{nameof(password)}' is not valid, must be at least 8 chars long and contain both letters and digits.", nameof(password));
            }

            // Create user registration
            var userRegistration = new UserRegistration
            {
                EmailAddress = emailAddress,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                UserRegistrationStatus = UserRegistrationStatus.WaitingForConfirmation
            };

            _userRegistrationRepository.Add(userRegistration);

            return $"UR{userRegistration.Id:N}".ToUpper();
        }

        public string ConfirmUserRegistration(string userRegistrationId)
        {
            if (!userRegistrationId.StartsWith("UR") || !Guid.TryParse(userRegistrationId.AsSpan(2), out var idAsGuid))
            {
                throw new ArgumentException($"'{nameof(userRegistrationId)}' is not valid, must be a UUID prefixed with UR.", nameof(userRegistrationId));
            }

            var userRegistration = _userRegistrationRepository.GetById(idAsGuid);

            if (userRegistration.UserRegistrationStatus == UserRegistrationStatus.Expired)
            {
                throw new ArgumentException("UserRegistration is expired.");
            }

            if (userRegistration.UserRegistrationStatus == UserRegistrationStatus.WaitingForConfirmation)
            {
                userRegistration.UserRegistrationStatus = UserRegistrationStatus.Confirmed;

                _userRegistrationRepository.Update(userRegistration);
            }

            return CreateUser(userRegistration);
        }

        private string CreateUser(UserRegistration userRegistration)
        {
            var user = new DataAccess.User.User
            {
                EmailAddress = userRegistration.EmailAddress,
                Password = userRegistration.Password,
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName
            };

            _userRepository.Add(user);

            return $"U{user.Id:N}".ToUpper();
        }
    }
}