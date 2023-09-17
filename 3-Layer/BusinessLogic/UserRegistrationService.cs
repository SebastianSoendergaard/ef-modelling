using DataAccess;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public class UserRegistrationService
    {
        private static string _passwordPattern = @"^(?=.*[0-9])(?=.*[a-zæøå])(.{8,})$";
        private static Regex _passwordValidator = new Regex(_passwordPattern, RegexOptions.IgnoreCase);

        private readonly IUserRegistrationRepository _repository;

        public UserRegistrationService(IUserRegistrationRepository repository)
        {
            _repository = repository;
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
                Id = Guid.NewGuid(),
                EmailAddress = emailAddress,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                UserRegistrationStatus = UserRegistrationStatus.WaitingForConfirmation
            };

            _repository.Add(userRegistration);

            return $"UR{userRegistration.Id:N}".ToUpper();
        }

        public void ConfirmUserRegistration(string id)
        {
            if (!id.StartsWith("UR") || !Guid.TryParse(id.AsSpan(2), out var idAsGuid))
            {
                throw new ArgumentException($"'{nameof(id)}' is not valid, must be a UUID prefixed with UR.", nameof(id));
            }

            var userRegistration = _repository.GetById(idAsGuid);

            if (userRegistration.UserRegistrationStatus == UserRegistrationStatus.Expired)
            {
                throw new ArgumentException("UserRegistration is expired.");
            }

            if (userRegistration.UserRegistrationStatus == UserRegistrationStatus.WaitingForConfirmation)
            {
                userRegistration.UserRegistrationStatus = UserRegistrationStatus.Confirmed;

                _repository.Update(userRegistration);
            }
        }
    }
}