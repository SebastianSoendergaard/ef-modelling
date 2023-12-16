using User.Domain.User;
using User.Domain.UserRegistration;

namespace User.Infrastructure
{
    // This factory enables us to mark UserDbContext as well as the actual repository implementations as internal
    // Using DI, this factory could be replaced by a simple extension method on the DI container
    public class RepositoryFactory
    {
        private readonly bool _fake;
        private readonly UserDbContext? _dbContext;

        public RepositoryFactory(bool fake)
        {
            _fake = fake;
            if (!fake)
            {
                _dbContext = new UserDbContext();
            }
        }

        public IUserRepository CreateUserRepository()
        {
            return _fake ? new FakeUserRepository() : new UserRepository(_dbContext!);
        }

        public IUserRegistrationRepository CreateUserRegistrationRepository()
        {
            return _fake ? new FakeUserRegistrationRepository() : new UserRegistrationRepository(_dbContext!);
        }
    }
}
