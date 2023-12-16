using Shared;
using User.Domain.UserRegistration;

namespace User.Infrastructure
{
    internal class FakeUserRegistrationRepository : FakeRepository<UserRegistration, UserRegistrationId>, IUserRegistrationRepository
    {
    }
}
