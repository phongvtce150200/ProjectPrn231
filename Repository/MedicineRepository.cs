using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        public List<Medicine> GetAllMedicine() => MedicineDAO.GetMedicine();

        public Medicine GetMedicineById(int id) => MedicineDAO.FindMedicineById(id);

        public void CreateMedicine(Medicine m) => MedicineDAO.CreateMedicine(m);

        public void UpdateMedicine(Medicine m) => MedicineDAO.UpdateMedicine(m);

        public void DeleteMedicine(Medicine m) => MedicineDAO.DeleteMedicine(m);

        public List<Medicine> GetMedicineByName(string s) => MedicineDAO.GetMedicineByName(s);


    }
}
