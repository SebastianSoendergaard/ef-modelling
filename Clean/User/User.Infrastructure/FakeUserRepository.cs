using User.Domain.User;

namespace User.Infrastructure
{
    public class FakeUserRepository : IUserRepository
    {
        private Dictionary<Guid, Domain.User.User> _users = new();

        public void Add(Domain.User.User user)
        {
            _users.Add(user.Id.Value, user);
        }

        public Domain.User.User GetById(UserId id)
        {
            return _users[id.Value];
        }

        public void Update(Domain.User.User user)
        {
            _users[user.Id.Value] = user;
        }
    }
}
