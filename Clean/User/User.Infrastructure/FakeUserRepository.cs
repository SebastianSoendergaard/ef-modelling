using Shared;
using User.Domain.User;

namespace User.Infrastructure
{
    internal class FakeUserRepository : FakeRepository<Domain.User.User, Domain.User.UserId>, IUserRepository
    {
    }
}
