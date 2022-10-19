using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAuthenticationRepository
    {
        Task<string> Login(LoginDTO loginDTO);
        Task<bool> Register(RegisterDTO registerDTO);
    }
}
