namespace DataAccess.User
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User GetById(Guid id)
        {
            return _dbContext.Users.Single(x => x.Id == id);
        }

        public void Update(User user)
        {
            _dbContext.SaveChanges();
        }
    }
}