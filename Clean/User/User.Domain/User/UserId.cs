using Shared;

namespace User.Domain.User
{
    public sealed class UserId : StronglyTypedValue<Guid>
    {
        public UserId(Guid value) : base(value)
        {
        }

        public string AsString()
        {
            return $"U{Value:N}".ToUpper();
        }

        public static UserId New()
        {
            return new UserId(Guid.NewGuid());
        }

        public static UserId From(Guid id)
        {
            return new UserId(id);
        }

        public static UserId From(string id)
        {
            if (!id.StartsWith("U") || !Guid.TryParse(id.AsSpan(1), out var result))
            {
                throw new ArgumentException($"'{nameof(id)}' is not valid, must be a UUID prefixed with U.", nameof(id));
            }

            return new UserId(result);
        }
    }
}
