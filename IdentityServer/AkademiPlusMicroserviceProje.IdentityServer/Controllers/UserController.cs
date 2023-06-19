using AkademiPlusMicroserviceProje.IdentityServer.Dtos;
using AkademiPlusMicroserviceProje.IdentityServer.Models;
using AkademiPlusMicroserviceProje.Shared.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var user = new ApplicationUser
            {
                UserName = signUpDto.UserName,
                Email = signUpDto.Email,
                City = signUpDto.City,
                Country = signUpDto.Country
            };
            var result=await _userManager.CreateAsync(user, signUpDto.Password);
            if(!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(),400));
            }
            else
            {
                return NoContent();
            }
        }
    }
}
