namespace PService.Infrastructure.Identity;

public interface ILoginService
{
    Task SignUp(UserRequest request);
    Task<bool> SingIn(string email,string password);
}
