using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MedicineDAO
    {
        public static List<Medicine> GetMedicine()
        {
            var listMedicine = new List<Medicine>();

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    //listInvoice = context.invoices.Include(x => x.Test).Include(y => y.Test.Appointment).ToList();
                    listMedicine = context.medicines.ToList();
                    if (listMedicine.Count == 0)
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listMedicine;
        }

        public static Medicine FindMedicineById(int medId)
        {
            Medicine m = new Medicine();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    m = context.medicines.SingleOrDefault(x => x.MedicineId == medId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return m;
        }

        public static void CreateMedicine(Medicine m)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.medicines.Add(m);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateMedicine(Medicine m)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Medicine>(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteMedicine(Medicine m)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var p1 = context.medicines.SingleOrDefault(c => c.MedicineId == m.MedicineId);
                    context.medicines.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<Medicine> GetMedicineByName(string name)
        {
            List<Medicine> list = new List<Medicine>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    list = context.medicines.Where(m => m.MedicineName.ToLower().Equals(name.ToLower())).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return list;
        }

    }
}
