
if (false)
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
    string userRegistrationId = userService.CreateUserRegistration("test@test.com", "abcd1234", "John", "Doe");
    string userId = userService.ConfirmUserRegistration(userRegistrationId);

    var userGroupId = userGroupService.CreateUserGroup("test group", "group created for testing");
    userGroupService.AddMemberToUserGroup(userGroupId, userId);
}
else
{
    // ==================================================
    // Clean approch with DDD
    // ==================================================

    // setup services
    var userRegistrationRepository = new User.Infrastructure.FakeUserRegistrationRepository();
    var userRepository = new User.Infrastructure.FakeUserRepository();

    var registerNewUserUseCase = new User.Application.RegisterNewUserUseCase(userRegistrationRepository);
    var confirmUserRegistrationUseCase = new User.Application.ConfirmUserRegistrationUseCase(userRegistrationRepository, userRepository);

    // execute
    string userRegistrationId = registerNewUserUseCase.Execute("test@test.com", "abcd1234", "John", "Doe", User.Application.RegisterNewUserUseCase.Gender.Male);
    string userId = confirmUserRegistrationUseCase.Execute(userRegistrationId);
}

