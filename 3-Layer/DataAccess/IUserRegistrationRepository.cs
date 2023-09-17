namespace DataAccess
{
    public interface IUserRegistrationRepository
    {
        void Add(UserRegistration userRegistration);
        void Update(UserRegistration userRegistration);
        UserRegistration GetById(Guid id);
    }
}
