namespace User.Domain.User
{
    public sealed class UserId
    {
        public Guid Value { get; private set; }

        public string AsString()
        {
            return $"U{Value:N}".ToUpper();
        }

        public static UserId New()
        {
            return new UserId { Value = Guid.NewGuid() };
        }

        public static UserId From(Guid id)
        {
            return new UserId { Value = id };
        }

        public static UserId From(string id)
        {
            if (!id.StartsWith("U") || !Guid.TryParse(id.AsSpan(1), out var result))
            {
                throw new ArgumentException($"'{nameof(id)}' is not valid, must be a UUID prefixed with U.", nameof(id));
            }

            return new UserId { Value = result };
        }
    }
}
