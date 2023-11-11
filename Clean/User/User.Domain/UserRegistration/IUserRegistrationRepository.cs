using Shared;

namespace User.Domain.UserRegistration
{
    public interface IUserRegistrationRepository : IRepository<UserRegistration, UserRegistrationId>
    {
    }
}
