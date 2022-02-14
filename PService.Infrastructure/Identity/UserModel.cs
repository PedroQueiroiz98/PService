using System.ComponentModel.DataAnnotations;
using CryptSharp;

namespace PService.Infrastructure.Identity;

public class UserModel
{   

    public int Id {get;set;}
    [Required]
    public string UserName {get;set;}
    [Required]
    public string Email {get;set;}

    [Required]
    public string PassWord {get;set;}
    
}
