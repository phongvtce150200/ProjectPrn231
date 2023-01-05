using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebClient.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly HttpClient client = null;
        private string ScheduleDetailsUrl = "";

        public AppointmentController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ScheduleDetailsUrl = "https://localhost:5001/api/ScheduleDetails";
        }
        /*public IActionResult Index()
        {
            string active = "active";
            ViewBag.Appointment = active;
            return View();
        }
        public async Task<IActionResult> GetEvents(int id = 1)
        {
            HttpResponseMessage respone = await client.GetAsync(ScheduleDetailsUrl + "/" + id);
            if (respone.IsSuccessStatusCode)
            {
                var data = respone.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                List<scheduleDetails> list = JsonSerializer.Deserialize<List<scheduleDetails>>(data, options);
                if (list == null)
                {
                    return View();
                }
                var events = new List<EventViewModel>();

                foreach (var item in list)
                {

                    EventViewModel eventViewModel = new EventViewModel()
                    {
                        eventID = item.ScheduleId,
                        title = "Meeting with Patient",
                        start = item.StartTime,
                        end = item.EndTime,
                        isFullDay = false
                    };
                    events.Add(eventViewModel);
                    events.ToArray();

                }
                JsonSerializerSettings jss = new JsonSerializerSettings();
                jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                string jsons = JsonConvert.SerializeObject(events, jss);
                return Content(jsons, "application/json");
            }
            return null;
        }*/

        public ActionResult Index()
        {
            ViewBag.appointments = GetScheduleData();
            return View();
        }
        public List<AppointmentData> GetScheduleData()
        {
            List<AppointmentData> appData = new List<AppointmentData>();
            appData.Add(new AppointmentData
            {
                Subject = "Paris",
                StartTime = new DateTime(2018, 2, 15, 10, 0, 0),
                EndTime = new DateTime(2018, 2, 15, 12, 30, 0)
            });
            return appData;
        }
        public class AppointmentData
        {
            public string Subject { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }
    }
}
