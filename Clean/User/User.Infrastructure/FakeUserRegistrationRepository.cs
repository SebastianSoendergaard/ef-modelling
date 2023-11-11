using Shared;
using User.Domain.UserRegistration;

namespace User.Infrastructure
{
    public class FakeUserRegistrationRepository : FakeRepository<UserRegistration, UserRegistrationId>, IUserRegistrationRepository
    {
    }
}
