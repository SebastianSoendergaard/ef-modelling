namespace DataAccess.User
{
    public class FakeUserRegistrationRepository : IUserRegistrationRepository
    {
        private Dictionary<Guid, UserRegistration> _userRegistrations = new();

        public void Add(UserRegistration userRegistration)
        {
            _userRegistrations.Add(userRegistration.Id, userRegistration);
        }

        public UserRegistration GetById(Guid id)
        {
            return _userRegistrations[id];
        }

        public void Update(UserRegistration userRegistration)
        {
            _userRegistrations[userRegistration.Id] = userRegistration;
        }
    }
}