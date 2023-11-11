using Shared;
using User.Domain.User;

namespace User.Infrastructure
{
    public class FakeUserRepository : FakeRepository<Domain.User.User, Domain.User.UserId>, IUserRepository
    {
    }
}
