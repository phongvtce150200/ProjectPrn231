using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Hubs;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebClient.Controllers
{
    public class MedicalExamController : Controller
    {
        IHubContext<SignalRServer> _signalRServer;
        private readonly HttpClient client = null;
        private string MedicineUrl = "";
        private string QueueApi = "";
        public MedicalExamController(IHubContext<SignalRServer> signalRServer)
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MedicineUrl = "https://localhost:5001/api/medicine";
            QueueApi = "https://localhost:5008/api/Queue";
            _signalRServer = signalRServer;
        }

        public IActionResult Index()
        {
            string active = "active";
            ViewBag.MedicalExam = active;
            return View();
        }

        public async Task<IActionResult> GetAllMedicines()
        {
            //FE active
            string active = "active";
            ViewBag.ActiveMedicines = active;

            //Get All Medicine
            HttpResponseMessage response = await client.GetAsync(MedicineUrl);
            string data = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Medicine> list = JsonSerializer.Deserialize<List<Medicine>>(data, options);
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string jsons = JsonConvert.SerializeObject(list, jss);
            return Content(jsons, "application/json");
        }
    }
}
