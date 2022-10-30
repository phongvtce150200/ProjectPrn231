using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private IMedicineRepository _medicineRepository = new MedicineRepository();
        // GET: api/<MedicineController>
        [HttpGet]
        public ActionResult<DataTableResponse> GetMedicine()
        {
            var list = _medicineRepository.GetAllMedicine();
            if(list == null)
            {
                return NoContent();
            }
            return new DataTableResponse
            {
                RecordsTotal = list.Count,
                RecordsFiltered = 10,
                Data = list.ToArray()
            };
        }

        // GET api/<MedicineController>/5
        [HttpGet("{id}")]
        public IActionResult GetMedicineById(int id)
        {

            var m = _medicineRepository.GetMedicineById(id);
            if (m == null)
            {
                return NotFound();
            }
            return Ok(m);
        }

        // POST api/<MedicineController>
        [HttpPost]
        public IActionResult CreateMedicine(Medicine m)
        {
            _medicineRepository.CreateMedicine(m);
            return Ok(m);
        }

        // PUT api/<MedicineController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateMedicine(int id, Medicine m)
        {
            var iTmp = _medicineRepository.GetMedicineById(id);
            if (iTmp == null)
            {
                return NotFound();
            }
            _medicineRepository.UpdateMedicine(m);
            return Ok(m);
        }

        // DELETE api/<MedicineController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMedicine(int id)
        {
            var iTmp = _medicineRepository.GetMedicineById(id);
            if (iTmp == null)
            {
                return NotFound();
            }
            _medicineRepository.DeleteMedicine(iTmp);
            return Ok(iTmp);
        }
    }
}
