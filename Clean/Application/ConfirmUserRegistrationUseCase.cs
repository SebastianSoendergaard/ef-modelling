using Domain.UserRegistration;

namespace Application
{
    public class ConfirmUserRegistrationUseCase
    {
        private readonly IUserRegistrationRepository _repository;

        public ConfirmUserRegistrationUseCase(IUserRegistrationRepository repository)
        {
            _repository = repository;
        }

        public void Execute(string id)
        {
            var userRegistrationId = UserRegistrationId.From(id);
            var userRegistration = _repository.GetById(userRegistrationId);

            userRegistration.Confirm();

            _repository.Update(userRegistration);
        }
    }
}