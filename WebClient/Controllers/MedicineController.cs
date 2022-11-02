using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Medicine = WebClient.Models.Medicine;

namespace WebClient.Controllers
{
    public class MedicineController : Controller
    {
        HttpClient client = new HttpClient();
        public async Task<IActionResult> Index()
        {
            string active = "active";
            ViewBag.MedicineManage = active;
            string SessionFullname = HttpContext.Session.GetString("fullname");
            ViewData["fullname"] = SessionFullname;
            string SessionRole = HttpContext.Session.GetString("role");
            ViewData["role"] = SessionRole;
            if (!SessionRole.Equals("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage respone = await client.GetAsync("https://localhost:5001/api/Medicine");
            string data = await respone.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            List<Medicine> list = JsonSerializer.Deserialize<List<Medicine>>(data, options);
            return View(list);
         
        }

        public async Task<IActionResult> CreateMedicine(Medicine medicine)
        {

            string data = JsonSerializer.Serialize(medicine);
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5001/api/Medicine", content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "Medicine");
            }
            return RedirectToAction("Index", "Medicine");
        }
        public async Task<IActionResult> Find(int id)
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Medicine/" + id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Medicine medicine = JsonSerializer.Deserialize<Medicine>(data);
                //var date = medicine.expiration.Date;

                var myMedicine = new
                {
                    medicineId = medicine.medicineId,
                    medicineName = medicine.medicineName,
                    price = medicine.medicineId,
                    expiration = medicine.expiration.ToShortDateString(),
                    amount = medicine.amount
                };

                return new JsonResult(myMedicine);

            }
            return RedirectToAction("Index", "Medicine");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMedicine(int MedicineId, Medicine medicine)
        {
            string data = JsonSerializer.Serialize(medicine);
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("https://localhost:5001/api/Medicine/" + MedicineId, content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "Medicine");
            }
            return RedirectToAction("Index", "Medicine");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMedicine(int medicineId)
        {
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:5001/api/Medicine/" + medicineId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "Medicine");
            }
            return RedirectToAction("Index", "Medicine");
        }
    }
}
