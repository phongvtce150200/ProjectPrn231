using DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Threading.Tasks;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private IAuthenticationRepository _authenticationRepository;

        public LoginController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginDTO loginDTO)
        {
            var resultToken = await _authenticationRepository.Login(loginDTO);
            if (string.IsNullOrEmpty(resultToken)) return BadRequest("Wrong Username or Password");
            return Ok(new { Token = resultToken });
        }
    }
}
