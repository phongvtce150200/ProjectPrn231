using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMedicineRepository
    {
        List<Medicine> GetAllMedicine();
        Medicine GetMedicineById(int id);
        void CreateMedicine(Medicine m);
        void UpdateMedicine(Medicine m);
        void DeleteMedicine(Medicine m);
        List<Medicine> GetMedicineByName(string s);
    }
}
