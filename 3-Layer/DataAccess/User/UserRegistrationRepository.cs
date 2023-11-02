namespace DataAccess.User
{
    public class UserRegistrationRepository : IUserRegistrationRepository
    {
        private readonly DbContext _dbContext;

        public UserRegistrationRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(UserRegistration userRegistration)
        {
            _dbContext.UserRegistrations.Add(userRegistration);
            _dbContext.SaveChanges();
        }

        public UserRegistration GetById(Guid id)
        {
            return _dbContext.UserRegistrations.Single(x => x.Id == id);
        }

        public void Update(UserRegistration userRegistration)
        {
            _dbContext.SaveChanges();
        }
    }
}