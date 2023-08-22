using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Services.Abstraction;
using SampleProject.Core.Utilities.Attributes;
using SampleProject.Model.Model.Authorize;
using SampleProject.Model.Utilities.Authentication;

namespace SampleProject.Api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizeService _authorizationService;

        public AuthorizationController(IAuthorizeService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            return Ok(_authorizationService.Login(loginModel));
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] PersonnelModel personnelModel)
        {
            return Ok(_authorizationService.Register(personnelModel));
        }
    }
}
