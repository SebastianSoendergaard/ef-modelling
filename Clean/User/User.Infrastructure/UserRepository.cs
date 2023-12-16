using User.Domain.User;

namespace User.Infrastructure
{
    internal class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Domain.User.User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void Update(Domain.User.User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public Domain.User.User GetById(UserId id)
        {
            return _dbContext.Users.Single(x => x.Id == id);
        }
    }
}
