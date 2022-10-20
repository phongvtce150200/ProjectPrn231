using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IScheduleRepository _scheduleRepository = new ScheduleRepository();
        // GET api/<DoctorController>/5
        [HttpGet("{DocId}")]
        public IActionResult GetScheduleByDoctorId(int DocId)
        {
            var d = _scheduleRepository.GetScheduleByDocId(DocId);
            if (d == null)
            {
                return NotFound();
            }
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string jsons = JsonConvert.SerializeObject(d, jss);
            return Content(jsons, "application/json");
        }
    }
}
