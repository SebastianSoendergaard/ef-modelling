using User.Domain.UserRegistration;

namespace User.Infrastructure
{
    public class FakeUserRegistrationRepository : IUserRegistrationRepository
    {
        private Dictionary<Guid, UserRegistration> _userRegistrations = new();

        public void Add(UserRegistration userRegistration)
        {
            _userRegistrations.Add(userRegistration.Id.Value, userRegistration);
        }

        public UserRegistration GetById(UserRegistrationId id)
        {
            return _userRegistrations[id.Value];
        }

        public void Update(UserRegistration userRegistration)
        {
            _userRegistrations[userRegistration.Id.Value] = userRegistration;
        }
    }
}
