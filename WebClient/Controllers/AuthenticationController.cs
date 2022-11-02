using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;
using WebClient.Models.DTO;

namespace WebClient.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly HttpClient client = null;
        private string LoginApi = "";

        public AuthenticationController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            LoginApi = "https://localhost:5001/api/Login";
        }

        public async Task<IActionResult> Login(Login userlogin)
        {
            string data = JsonSerializer.Serialize(userlogin);
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(LoginApi, content);

            var token = await response.Content.ReadAsStringAsync();
            string[] AcceptToken = token.Split('"');
            if (token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var respone2 = await client.GetAsync(LoginApi + "/GetUserByToken?token=" + AcceptToken[1]);
            string token2 = await respone2.Content.ReadAsStringAsync();

            AccountDTO account = JsonSerializer.Deserialize<AccountDTO>(token2);
            HttpContext.Session.SetString("role", account.role);
            string SessionRole = HttpContext.Session.GetString("role");
            HttpContext.Session.SetString("token", AcceptToken[1]);
            string SessionToken = HttpContext.Session.GetString("token");
            HttpContext.Session.SetString("fullname", account.fullName);
            string SessionFullName = HttpContext.Session.GetString("fullname");
            ViewData["FullName"] = SessionFullName;
            ViewData["Role"] = SessionRole;
            if (account.role.Equals("Doctor"))
            {
                return RedirectToAction("Index", "MedicalExam");
            }
            else
            {
                if (account.role.Equals("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (account.role.Equals("Nurse"))
                {
                    return RedirectToAction("Index", "ReceivePatient");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }


            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            HttpContext.Session.Remove("fullname");
            HttpContext.Session.Remove("role");
            return RedirectToAction("Index","Home"); 
        }
    }
}
