using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.User
{
    [Table("3layer.users")]
    public class User
    {
        public Guid Id { get; init; }
        public string EmailAddress { get; set; } = default!;
        public string? FirstName { get; set; } = default!;
        public string? LastName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
