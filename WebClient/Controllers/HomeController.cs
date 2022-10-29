using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.DTO;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            
            string SessionFullname = HttpContext.Session.GetString("fullname");
            ViewData["fullname"] = SessionFullname;
            string SessionRole = HttpContext.Session.GetString("role");
            ViewData["role"] = SessionRole;
            
            if(SessionFullname == null && SessionRole == null)
            {
                return View();
            }
            if (SessionRole.Equals("Admin"))
            {
                return RedirectToAction("Index", "DoctorPage");
            }
            if (SessionRole.Equals("Nurse"))
            {
                return RedirectToAction("Index", "ReceivePatient");
            }
            if (SessionRole.Equals("Doctor"))
            {
                return RedirectToAction("Index", "MedicalExam");
            }
            return View();
        }

        public async Task<IActionResult> Login(Login userlogin)
        {
            using (var client = new HttpClient())
            {
                string data = JsonSerializer.Serialize(userlogin);
                var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:5001/api/Login", content);

                string token = await response.Content.ReadAsStringAsync();

                if (token == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                
                var respone2 = await client.GetAsync("https://localhost:5001/api/Login/GetUserByToken?token=" + token);
                string token2 = await respone2.Content.ReadAsStringAsync();

                AccountDTO account = JsonSerializer.Deserialize<AccountDTO>(token2);
                HttpContext.Session.SetString("role", account.role);
                string SessionRole = HttpContext.Session.GetString("role");
                HttpContext.Session.SetString("token", token);
                string SessionToken = HttpContext.Session.GetString("token");
                HttpContext.Session.SetString("fullname", account.fullName);
                string SessionFullName = HttpContext.Session.GetString("fullname");
                if (account.role.Equals("Doctor"))
                {
                    return RedirectToAction("Index", "MedicalExam");
                } else
                {
                    if(account.role.Equals("Admin"))
                    {
                        return RedirectToAction("Index", "DoctorPage");
                    } else if(account.role.Equals("Nurse"))
                    {
                        return RedirectToAction("Index", "ReceivePatient");
                    } else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }             
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("role");
            HttpContext.Session.Remove("token");
            HttpContext.Session.Remove("fullname");
            return RedirectToAction("Index", "Home");

        }


    }
}
