namespace DataAccess.UserGroup
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly DbContext _dbContext;

        public UserGroupRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(UserGroup userGroup)
        {
            _dbContext.UserGroups.Add(userGroup);
            _dbContext.SaveChanges();
        }

        public UserGroup GetById(Guid id)
        {
            return _dbContext.UserGroups.Single(x => x.Id == id);
        }

        public void Update(UserGroup userGroup)
        {
            _dbContext.UserGroups.Update(userGroup);
            _dbContext.SaveChanges();
        }
    }
}
