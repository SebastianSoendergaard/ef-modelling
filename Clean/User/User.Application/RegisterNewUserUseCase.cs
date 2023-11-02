using User.Domain.Shared;
using User.Domain.UserRegistration;

namespace User.Application
{
    public class RegisterNewUserUseCase
    {
        private readonly IUserRegistrationRepository _repository;

        public RegisterNewUserUseCase(IUserRegistrationRepository repository)
        {
            _repository = repository;
        }

        public string Execute(string emailAddress, string password, string? firstName, string? lastName, Gender? gender)
        {
            var userRegistrationId = UserRegistrationId.New();
            var email = EmailAddress.From(emailAddress);
            var pass = Password.From(password);
            var name = FullName.From(firstName, lastName);

            var userRegistration = UserRegistration.Create(userRegistrationId, email, pass, name, ConvertGender(gender ?? Gender.Unknown));

            _repository.Add(userRegistration);

            return userRegistrationId.AsString();
        }

        private User.Domain.Shared.Gender ConvertGender(Gender gender)
        {
            return gender switch
            {
                Gender.Unknown => User.Domain.Shared.Gender.Unknown,
                Gender.Male => User.Domain.Shared.Gender.Male,
                Gender.Female => User.Domain.Shared.Gender.Female,
                _ => throw new NotImplementedException("Unknown gender type")
            };
        }

        public enum Gender
        {
            Unknown,
            Male,
            Female
        }
    }
}