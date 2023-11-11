using DddStuff;
using User.Domain.Shared;

namespace User.Domain.User
{
    public sealed class User : Aggregate<UserId>
    {
        public UserId Id { get; private set; } = default!;
        public EmailAddress EmailAddress { get; private set; } = default!;
        public FullName FullName { get; private set; } = default!;
        public Password Password { get; private set; } = default!;
        public Gender Gender { get; private set; } = Gender.Unknown;

        private User() : base()
        {
        }

        public static User Create(UserId userId, EmailAddress emailAddress, Password password, FullName name, Gender gender)
        {
            return new User
            {
                Id = userId,
                EmailAddress = emailAddress,
                Password = password,
                FullName = name,
                Gender = gender,
            };
        }
    }
}
