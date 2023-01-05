using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WebClient.Models;
using BusinessObject;
using Syncfusion.EJ2.Linq;
using System.Net.Http;
using System.Linq;
using Event = WebClient.Models.Event;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebClient.Controllers
{
    public partial class ScheduleController : Controller
    {
        public IActionResult Overview()
        {
            return View();
        }
    }
}
