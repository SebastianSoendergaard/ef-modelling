namespace Domain.UserRegistration
{
    public sealed class EmailAddress
    {
        public string Value { get; private set; } = default!;

        private EmailAddress()
        {
        }

        private EmailAddress(string value)
        {
            Value = value;
        }

        public static EmailAddress From(string email)
        {
            if (string.IsNullOrEmpty(email) || email.Length > 320 || !email.Contains('@', StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"'{nameof(email)}' is not valid.", nameof(email));
            }

            return new EmailAddress(email.ToLowerInvariant());
        }
    }
}
