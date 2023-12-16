using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.UserGroup
{
    [Table("3layer.user_groups")]
    public class UserGroup
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = default!;

        [Column("description")]
        public string Description { get; set; } = default!;

        [Column("members")]
        public List<UserGroupMember> Members { get; } = new();
    }
}
