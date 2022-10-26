using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using WebClient.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebClient.Controllers
{
    public class ReceivePatientController : Controller
    {
        private readonly HttpClient client = null;
        private string PatientUrl = "";

        public ReceivePatientController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            PatientUrl = "https://localhost:5001/api/Patient";
        }
        public IActionResult Index()
        {
            //FE active
            string active = "active";
            ViewBag.ReceivePatient = active;

            return View();
        }


        public async Task<IActionResult> GetAllPatient()
        {
            //FE active
            string active = "active";
            ViewBag.ReceivePatient = active;

            //Get All Patient List
            HttpResponseMessage respone = await client.GetAsync(PatientUrl);
            string data = await respone.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Patient> list = JsonSerializer.Deserialize<List<Patient>>(data, options);
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string jsons = JsonConvert.SerializeObject(list, jss);
            return Content(jsons, "application/json");
        }
    }
}
