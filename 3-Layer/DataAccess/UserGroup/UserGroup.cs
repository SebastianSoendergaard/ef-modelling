using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.UserGroup
{
    [Table("3layer.user_groups")]
    public class UserGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<UserGroupMember> Members { get; } = new();
    }
}
