using Shared;
using System.Text.RegularExpressions;

namespace User.Domain.Shared
{
    public sealed class Password : ValueObject
    {
        // TODO: password pattern requires dependency!?!
        public static string PasswordPattern = @"^(?=.*[0-9])(?=.*[a-zæøå])(.{8,})$";
        private static Regex _passwordValidator = new Regex(PasswordPattern, RegexOptions.IgnoreCase);

        public string Value { get; private set; }

        private Password()
        {
        }

        private Password(string password)
        {
            Value = password;
        }

        public static Password From(string password)
        {
            if (!_passwordValidator.IsMatch(password))
            {
                throw new ArgumentException($"'{nameof(password)}' is not valid, must be at least 8 chars long and contain both letters and digits.", nameof(password));
            }

            // TODO: Maybe we should hash password here to avoid clear text, but it will require a dependency!?!

            return new Password(password);
        }
    }
}
