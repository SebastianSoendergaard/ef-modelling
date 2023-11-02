using DataAccess.UserGroup;

namespace BusinessLogic.UserGroup
{
    public class UserGroupService
    {
        private readonly IUserGroupRepository _userGroupRepository;

        public UserGroupService(IUserGroupRepository userGroupRepository)
        {
            _userGroupRepository = userGroupRepository;
        }

        public string CreateUserGroup(string name, string description)
        {
            var userGroup = new DataAccess.UserGroup.UserGroup
            {
                Name = name,
                Description = description
            };

            _userGroupRepository.Add(userGroup);

            return $"UG{userGroup.Id:N}".ToUpper();
        }

        public void AddMemberToUserGroup(string userGroupId, string memberId)
        {
            if (!userGroupId.StartsWith("UG") || !Guid.TryParse(userGroupId.AsSpan(2), out var idAsGuid))
            {
                throw new ArgumentException($"'{nameof(userGroupId)}' is not valid, must be a UUID prefixed with UG.", nameof(userGroupId));
            }

            var userGroup = _userGroupRepository.GetById(idAsGuid);

            var member = new DataAccess.UserGroup.UserGroupMember
            {
                MemberId = memberId,
            };

            userGroup.Members.Add(member);

            _userGroupRepository.Update(userGroup);
        }
    }
}
