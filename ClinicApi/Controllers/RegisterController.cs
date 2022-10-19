using DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Threading.Tasks;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RegisterController : ControllerBase
    {
        private IAuthenticationRepository _authenticationRepository;

        public RegisterController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDTO registerDTO)
        {
            var check = await _authenticationRepository.Register(registerDTO);
            return Ok(check);
        }
    }
}
