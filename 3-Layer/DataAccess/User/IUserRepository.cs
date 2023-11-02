namespace DataAccess.User
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        User GetById(Guid id);
    }
}
