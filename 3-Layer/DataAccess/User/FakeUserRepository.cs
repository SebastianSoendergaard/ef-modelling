namespace DataAccess.User
{
    public class FakeUserRepository : IUserRepository
    {
        private Dictionary<Guid, User> _users = new();

        public void Add(User user)
        {
            _users.Add(user.Id, user);
        }

        public User GetById(Guid id)
        {
            return _users[id];
        }

        public void Update(User user)
        {
            _users[user.Id] = user;
        }
    }
}