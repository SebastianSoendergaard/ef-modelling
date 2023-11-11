using DddStuff;
using User.Domain.Shared;
using User.Domain.User;

namespace User.Domain.UserRegistration
{
    public sealed class UserRegistration : Aggregate<UserRegistrationId>
    {
        public UserRegistrationId Id { get; private set; }
        public UserRegistrationStatus UserRegistrationStatus { get; private set; } = default!;
        public EmailAddress EmailAddress { get; private set; } = default!;
        public FullName FullName { get; private set; } = default!;
        public Password Password { get; private set; } = default!;
        public Gender Gender { get; private set; } = Gender.Unknown;

        private UserRegistration()
        {
        }

        private UserRegistration(UserRegistrationId userRegistrationId, EmailAddress emailAddress, Password password, FullName fullName, Gender gender, UserRegistrationStatus userRegistrationStatus)
        {
            Id = userRegistrationId;
            UserRegistrationStatus = userRegistrationStatus;
            EmailAddress = emailAddress;
            Password = password;
            FullName = fullName;
            Gender = gender;
        }

        public static UserRegistration Create(UserRegistrationId userRegistrationId, EmailAddress emailAddress, Password password, FullName name, Gender gender)
        {
            var userRegistration = new UserRegistration(userRegistrationId, emailAddress, password, name, gender, UserRegistrationStatus.WaitingForConfirmation);
            return userRegistration;
        }

        public User.User Confirm()
        {
            if (UserRegistrationStatus == UserRegistrationStatus.Expired)
            {
                throw new DomainException("UserRegistration is expired.");
            }

            if (UserRegistrationStatus == UserRegistrationStatus.WaitingForConfirmation)
            {
                UserRegistrationStatus = UserRegistrationStatus.Confirmed;
            }

            return User.User.Create(UserId.From(Id.Value), EmailAddress, Password, FullName, Gender);
        }
    }
}
