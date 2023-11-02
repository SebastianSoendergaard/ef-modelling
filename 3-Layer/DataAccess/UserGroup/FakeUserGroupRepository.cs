namespace DataAccess.UserGroup
{
    public class FakeUserGroupRepository : IUserGroupRepository
    {
        private Dictionary<Guid, UserGroup> _userGroups = new();

        public void Add(UserGroup user)
        {
            _userGroups.Add(user.Id, user);
        }

        public UserGroup GetById(Guid id)
        {
            return _userGroups[id];
        }

        public void Update(UserGroup user)
        {
            _userGroups[user.Id] = user;
        }
    }
}