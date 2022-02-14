using System.Net;
using Microsoft.AspNetCore.Mvc;
using PService.Infrastructure.Identity;

namespace PService.API.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class AccountController : ControllerBase
{

    private readonly ILogger<AccountController> _logger;
    private readonly ILoginService _loginService;

    public AccountController(
        ILogger<AccountController> logger,
        ILoginService  loginService){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
    }

    [HttpPost("sign-in")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadGateway)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<ActionResult> SignIn([FromBody] LoginRequest request){

        var result = await _loginService.SingIn(request.Email,request.PassWord);
        if(result)return Ok();
        return Unauthorized();
    }

    [HttpPost("sign-up")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> SignUp([FromBody] UserRequest request){

        await _loginService.SignUp(request);
        return Ok();
    }
    
}
