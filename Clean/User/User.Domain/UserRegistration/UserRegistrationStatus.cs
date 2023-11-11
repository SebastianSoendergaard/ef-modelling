using DddStuff;

namespace User.Domain.UserRegistration
{
    public sealed class UserRegistrationStatus : ValueObject
    {
        public static UserRegistrationStatus WaitingForConfirmation = new(nameof(WaitingForConfirmation));
        public static UserRegistrationStatus Confirmed = new(nameof(Confirmed));
        public static UserRegistrationStatus Expired = new(nameof(Expired));

        public static UserRegistrationStatus From(string value)
        {
            if (value == WaitingForConfirmation._value)
            {
                return WaitingForConfirmation;
            }

            if (value == Confirmed._value)
            {
                return Confirmed;
            }

            if (value == Expired._value)
            {
                return Expired;
            }

            throw new ArgumentException($"'{nameof(value)}' is not valid.", nameof(value));
        }

        public string AsString()
        {
            return _value;
        }

        private readonly string _value;

        private UserRegistrationStatus(string value)
        {
            _value = value;
        }

        private UserRegistrationStatus()
        {
            _value = string.Empty;
        }
    }
}
