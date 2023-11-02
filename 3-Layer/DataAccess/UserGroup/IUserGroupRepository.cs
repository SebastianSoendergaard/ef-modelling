namespace DataAccess.UserGroup
{
    public interface IUserGroupRepository
    {
        void Add(UserGroup userGroup);
        void Update(UserGroup userGroup);
        UserGroup GetById(Guid id);
    }
}
