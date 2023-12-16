using User.Domain.UserRegistration;

namespace User.Infrastructure
{
    internal class UserRegistrationRepository : IUserRegistrationRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRegistrationRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(UserRegistration userRegistration)
        {
            _dbContext.UserRegistrations.Add(userRegistration);
            _dbContext.SaveChanges();
        }

        public void Update(UserRegistration userRegistration)
        {
            _dbContext.UserRegistrations.Update(userRegistration);
            _dbContext.SaveChanges();
        }

        public UserRegistration GetById(UserRegistrationId id)
        {
            return _dbContext.UserRegistrations.Single(x => x.Id == id);
        }
    }
}
