using User.Domain.User;

namespace User.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public void Add(Domain.User.User user)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.User.User user)
        {
            throw new NotImplementedException();
        }

        public Domain.User.User GetById(UserId id)
        {
            throw new NotImplementedException();
        }
    }
}
