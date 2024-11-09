using AuthECAPI.Interfaces;
using AuthECAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AuthECAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> SignUp(AppUserViewModel appUserViewModel)
        {
            var response = await _userServices.UserSignUp(appUserViewModel);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
