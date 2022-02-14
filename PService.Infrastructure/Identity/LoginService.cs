using CryptSharp;
using Microsoft.EntityFrameworkCore;

namespace PService.Infrastructure.Identity;

public class LoginService : ILoginService
{

    private readonly OrderContext _context;
    public LoginService(OrderContext context){
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task SignUp(UserRequest request){

        _context.Add(new UserModel(){
            UserName = request.UserName,
            PassWord = request.PassWord,
            Email = request.Email
        });
        await _context.SaveEntitiesAsync();
    }
    public async Task<bool> SingIn(string email,string password){

        var user =  await _context.Users.SingleOrDefaultAsync(x=>x.Email.Equals(email));
        return Crypter.CheckPassword(password, user.PassWord);
        
    }
}
