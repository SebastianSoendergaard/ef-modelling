using User.Domain.User;
using User.Domain.UserRegistration;

namespace User.Application
{
    public class ConfirmUserRegistrationUseCase
    {
        private readonly IUserRegistrationRepository _userRegistrationRepository;
        private readonly IUserRepository _userRepository;

        public ConfirmUserRegistrationUseCase(IUserRegistrationRepository userRegistrationRepository, IUserRepository userRepository)
        {
            _userRegistrationRepository = userRegistrationRepository;
            _userRepository = userRepository;
        }

        public string Execute(string id)
        {
            var userRegistrationId = UserRegistrationId.From(id);
            var userRegistration = _userRegistrationRepository.GetById(userRegistrationId);

            var user = userRegistration.Confirm();

            _userRegistrationRepository.Update(userRegistration);
            _userRepository.Add(user);

            return user.Id.AsString();
        }
    }
}