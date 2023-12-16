namespace UserGroup.Domain.UserGroup
{
    public sealed class UserGroup
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        private readonly List<UserGroupMember> _members = new();
        public IReadOnlyCollection<UserGroupMember> Members => _members;

        private UserGroup()
        {
        }

        public static UserGroup Create(string name, string description)
        {
            return new UserGroup
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description
            };
        }

        public void AddMember(UserGroupMember member)
        {
            _members.Add(member);
        }

        public void RemoveMember(UserGroupMember member)
        {
            _members.Remove(member);
        }
    }
}
