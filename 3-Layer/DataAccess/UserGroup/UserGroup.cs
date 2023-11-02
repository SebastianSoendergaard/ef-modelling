namespace DataAccess.UserGroup
{
    public class UserGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<UserGroupMember> Members { get; } = new();
    }
}
