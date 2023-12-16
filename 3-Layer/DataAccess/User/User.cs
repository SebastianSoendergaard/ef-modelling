using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.User
{
    [Table("3layer.users")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; init; }

        [Required(ErrorMessage = "Email address must have a value")]
        [MaxLength(100)]
        [Column("email_address")]
        public string EmailAddress { get; set; } = default!;

        [Column("first_name")]
        [MaxLength(50)]
        public string? FirstName { get; set; } = default!;

        [Column("last_name")]
        [MaxLength(50)]
        public string? LastName { get; set; } = default!;

        [Column("password")]
        public string Password { get; set; } = default!;
    }
}
