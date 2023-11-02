using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.UserGroup
{
    [Table("3layer.user_group_members")]
    public class UserGroupMember
    {
        public Guid Id { get; set; }
        public string MemberId { get; set; } = default!;
    }
}
