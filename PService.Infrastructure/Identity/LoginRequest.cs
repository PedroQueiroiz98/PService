using System.ComponentModel.DataAnnotations;

namespace PService.Infrastructure.Identity;

public class LoginRequest
{

    [Required]
    public string Email {get;set;}
    [Required]
    public string PassWord {get;set;}


}
