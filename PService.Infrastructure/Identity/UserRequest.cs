using System.ComponentModel.DataAnnotations;
using CryptSharp;

namespace PService.Infrastructure.Identity;

public class UserRequest
{   

    [Required]
    public string UserName {get;set;}
    [Required]
    public string Email {get;set;}
    private string _password;
    [Required]
    public string PassWord {

        get=>_password;
        set{
            _password = Crypter.Blowfish.Crypt(value);
        }
    }
}
