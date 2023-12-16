using Shared;

namespace User.Domain.UserRegistration
{
    public sealed class UserRegistrationId : StronglyTypedValue<Guid>
    {
        public string AsString()
        {
            return $"UR{Value:N}".ToUpper();
        }

        private UserRegistrationId(Guid value) : base(value)
        {
        }

        public static UserRegistrationId New()
        {
            return new UserRegistrationId(Guid.NewGuid());
        }

        public static UserRegistrationId From(Guid id)
        {
            return new UserRegistrationId(id);
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
