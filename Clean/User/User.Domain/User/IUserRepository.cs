using Shared;

namespace User.Domain.User
{
    public interface IUserRepository : IRepository<User, UserId>
    {
    }
}
