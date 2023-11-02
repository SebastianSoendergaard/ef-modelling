namespace Domain.UserRegistration
{
    public sealed class UserRegistrationId
    {
        public Guid Value { get; private set; }

        public string AsString()
        {
            return $"UR{Value:N}".ToUpper();
        }

        private UserRegistrationId(Guid value)
        {
            Value = value;
        }

        public static UserRegistrationId New()
        {
            return new UserRegistrationId(Guid.NewGuid());
        }

        public static UserRegistrationId From(string id)
        {
            if (!id.StartsWith("UR") || !Guid.TryParse(id.AsSpan(2), out var result))
            {
                throw new ArgumentException($"'{nameof(id)}' is not valid, must be a UUID prefixed with UR.", nameof(id));
            }

            return new UserRegistrationId(result);
        }
    }
}
