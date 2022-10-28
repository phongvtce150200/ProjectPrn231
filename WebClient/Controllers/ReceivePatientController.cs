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
using System;
using Microsoft.AspNetCore.SignalR;
using WebClient.Hubs;

namespace WebClient.Controllers
{
    public class ReceivePatientController : Controller
    {
        private readonly HttpClient client = null;
        private string PatientUrl = "";
        private string QueueApi = "";
        IHubContext<SignalRServer> _signalRServer;

        public ReceivePatientController(IHubContext<SignalRServer> signalRServer)
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            PatientUrl = "https://localhost:5001/api/Patient";
            QueueApi = "https://localhost:5008/api/Queue";
            _signalRServer = signalRServer;
        }
        public IActionResult Index()
        {
            //FE active
            string active = "active";
            ViewData["ReceivePatient"] = active;

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


        [HttpPost]
        public async Task<IActionResult> CreateQueueRequest(string FullName, DateTime Birthday, string Gender, string Address, string City, string PhoneNumber, float Pulse, float BloodPressure, float Temperature, float Weight, float Height)
        {
            string active = "active";
            ViewData["ReceivePatient"] = active;

            Queue queue = new Queue
            {
                PatientId = 1,
                DocId = 1,
                PatientFullName = FullName,
                PatientBirthDay = Birthday,
                PatientGender = Gender,
                Address = Address,
                PhoneNumber = "0909090090",
                Pusle = Pulse,
                BloodPressure = BloodPressure,
                Temperature = Temperature,
                Weight = Weight,
                Height = Height,
                Status = true
            };
            if (ModelState.IsValid)
            {
                string data = JsonSerializer.Serialize(queue);
                var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage respone = await client.PostAsync(QueueApi, content);
                if (respone.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await _signalRServer.Clients.All.SendAsync("LoadPatients");
                    return RedirectToAction("Index","ReceivePatient");
                }
                return BadRequest(respone);
            }
            return BadRequest(ModelState);
        }
    }
}
