using Domain.UserRegistration;

namespace Application
{
    public class RegisterNewUserUseCase
    {
        private readonly IUserRegistrationRepository _repository;

        public RegisterNewUserUseCase(IUserRegistrationRepository repository)
        {
            _repository = repository;
        }

        public string Execute(string emailAddress, string password, string? firstName, string? lastName)
        {
            var userRegistrationId = UserRegistrationId.New();
            var email = EmailAddress.From(emailAddress);
            var pass = Password.From(password);
            var name = FullName.From(firstName, lastName);

            var userRegistration = UserRegistration.Create(userRegistrationId, email, pass, name);

            _repository.Add(userRegistration);

            return userRegistrationId.AsString();
        }
    }
}