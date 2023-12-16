using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.User
{
    [Table("3layer.user_registrations")]
    public class UserRegistration
    {
        [Key]
        [Column("id")]
        public Guid Id { get; init; }

        [Column("status")]
        public UserRegistrationStatus UserRegistrationStatus { get; set; } = default!;

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

    public enum UserRegistrationStatus
    {
        WaitingForConfirmation = 1,
        Confirmed = 2,
        Expired = 3
    }
}
