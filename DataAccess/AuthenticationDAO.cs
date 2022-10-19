using BusinessObject;
using DataAccess.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AuthenticationDAO
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;


        public AuthenticationDAO(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginDTO loginDTO)
        { 
            var user = await _userManager.FindByNameAsync(loginDTO.UserName);
            if (user == null) throw new Exception("Wrong Username or Password");

            // var result = await _signInManager.PasswordSignInAsync(check,loginDTO.Password,false,false);
            var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!result)
            {
                return null;
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim("Id", user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, roles.LastOrDefault()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(_configuration["JWT:Issuer"], _configuration["JWT:Issuer"], claims, expires: DateTime.Now.AddDays(3), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<bool> Register(RegisterDTO registerDTO)
        {
            var user = new User
            {
                UserName = registerDTO.Username,
                Email = registerDTO.Email
            };
            if (!Equals(registerDTO.Password, registerDTO.ConfirmPassword))
            {
               return false;
            }
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Patient);
                return true;
            }

            var errors = result.Errors;

            return false;
        }
       
    }
}
