
if (false)
{
    // ==================================================
    // normal 3-layer approch
    // ==================================================

    var repository = new DataAccess.FakeUserRegistrationRepository();

    var service = new BusinessLogic.UserRegistrationService(repository);

    string id = service.CreateUserRegistration("test@test.com", "abcd1234", "John", "Doe");

    service.ConfirmUserRegistration(id);
}
else
{
    // ==================================================
    // Clean approch with DDD
    // ==================================================

    var repository = new Infrastructure.FakeUserRegistrationRepository();

    string id = new Application.RegisterNewUserUseCase(repository).Execute("test@test.com", "abcd1234", "John", "Doe");

    new Application.ConfirmUserRegistrationUseCase(repository).Execute(id);
}

