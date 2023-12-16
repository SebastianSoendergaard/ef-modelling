using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.UserGroup
{
    [Table("3layer.user_group_members")]
    public class UserGroupMember
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("member_id")]
        public string MemberId { get; set; } = default!;

        [NotMapped] // Only for navigation
        public UserGroup UserGroup { get; set; } = default!;

        [ForeignKey(nameof(UserGroup))]
        public Guid UserGroupId { get; set; }
    }
}
