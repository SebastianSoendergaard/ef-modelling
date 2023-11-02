namespace DataAccess.User
{
    public class UserRegistration
    {
        public Guid Id { get; init; }
        public UserRegistrationStatus UserRegistrationStatus { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public string? FirstName { get; set; } = default!;
        public string? LastName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }

    public enum UserRegistrationStatus
    {
        WaitingForConfirmation = 1,
        Confirmed = 2,
        Expired = 3
    }
}
