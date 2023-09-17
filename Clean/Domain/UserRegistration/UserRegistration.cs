using Domain.Shared;

namespace Domain.UserRegistration
{
    public sealed class UserRegistration
    {
        public UserRegistrationId Id { get; private set; }
        public UserRegistrationStatus UserRegistrationStatus { get; private set; } = default!;
        public EmailAddress EmailAddress { get; private set; } = default!;
        public FullName FullName { get; private set; } = default!;
        public Password Password { get; private set; } = default!;

        private UserRegistration()
        {
        }

        private UserRegistration(UserRegistrationId userRegistrationId, EmailAddress emailAddress, Password password, FullName fullName, UserRegistrationStatus userRegistrationStatus)
        {
            UserRegistrationStatus = userRegistrationStatus;
            EmailAddress = emailAddress;
            Password = password;
            FullName = fullName;
            Id = userRegistrationId;
        }

        public static UserRegistration Create(UserRegistrationId userRegistrationId, EmailAddress emailAddress, Password password, FullName name)
        {
            var userRegistration = new UserRegistration(userRegistrationId, emailAddress, password, name, UserRegistrationStatus.WaitingForConfirmation);
            return userRegistration;
        }

        public void Confirm()
        {
            if (UserRegistrationStatus == UserRegistrationStatus.Expired)
            {
                throw new DomainException("UserRegistration is expired.");
            }

            if (UserRegistrationStatus == UserRegistrationStatus.WaitingForConfirmation)
            {
                UserRegistrationStatus = UserRegistrationStatus.Confirmed;
            }
        }
    }
}
