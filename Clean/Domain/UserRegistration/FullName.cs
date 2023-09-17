namespace Domain.UserRegistration
{
    public sealed class FullName
    {
        private FullName()
        {
        }

        private FullName(string? firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }

        public static FullName From(string? firstName, string? lastName)
        {
            return new FullName(firstName, lastName);
        }
    }
}
