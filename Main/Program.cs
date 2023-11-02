
if (true)
{
    // ==================================================
    // Normal 3-layer approch
    // ==================================================

    // setup services
    var dbContext = new DataAccess.DbContext();

    var userRegistrationRepository = new DataAccess.User.UserRegistrationRepository(dbContext);
    var userRepository = new DataAccess.User.UserRepository(dbContext);
    var userGroupRepository = new DataAccess.UserGroup.UserGroupRepository(dbContext);

    var userService = new BusinessLogic.User.UserService(userRegistrationRepository, userRepository);
    var userGroupService = new BusinessLogic.UserGroup.UserGroupService(userGroupRepository);

    // execute
    string registrationId = userService.CreateUserRegistration("test@test.com", "abcd1234", "John", "Doe");
    string userId = userService.ConfirmUserRegistration(registrationId);

    var userGroupId = userGroupService.CreateUserGroup("test group", "group created for testing");
    userGroupService.AddMemberToUserGroup(userGroupId, userId);
}
else
{
    // ==================================================
    // Clean approch with DDD
    // ==================================================

    var repository = new Infrastructure.FakeUserRegistrationRepository();

    string id = new Application.RegisterNewUserUseCase(repository).Execute("test@test.com", "abcd1234", "John", "Doe", Application.RegisterNewUserUseCase.Gender.Male);

    new Application.ConfirmUserRegistrationUseCase(repository).Execute(id);
}

