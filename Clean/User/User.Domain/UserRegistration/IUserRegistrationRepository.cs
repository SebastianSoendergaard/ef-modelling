namespace Domain.UserRegistration
{
    public interface IUserRegistrationRepository
    {
        void Add(UserRegistration userRegistration);
        void Update(UserRegistration userRegistration);
        UserRegistration GetById(UserRegistrationId id);
    }
}
