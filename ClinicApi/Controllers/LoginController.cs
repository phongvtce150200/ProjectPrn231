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
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var resultToken = await _authenticationRepository.Login(loginDTO);
            if (string.IsNullOrEmpty(resultToken)) return BadRequest("Wrong Username or Password");
            return Ok(resultToken);
        }

        [HttpGet("GetUserByToken")]
        public UserandRole getUserBytoken(string token)
        {
            UserandRole user = new UserandRole();
            user = _authenticationRepository.GetByToken(token);

            return user;
        }
    }
}
