using DataAccess;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        AuthenticationDAO authenticationDAO;

        public AuthenticationRepository(AuthenticationDAO authenticationDAO)
        {
            this.authenticationDAO = authenticationDAO;
        }

        public Task<string> Login(LoginDTO loginDTO) => authenticationDAO.Login(loginDTO);



        public Task<bool> Register(RegisterDTO registerDTO) => authenticationDAO.Register(registerDTO);
    }
}
