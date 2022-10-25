using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PatientDAO
    {
        public static List<Patient> GetPatient()
        {
            var listPatient = new List<Patient>();

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    //listInvoice = context.invoices.Include(x => x.Test).Include(y => y.Test.Appointment).ToList();
                    listPatient = context.patients.Include(x => x.Account).ToList();
                    if (listPatient.Count == 0)
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listPatient;
        }

        public static Patient FindPatientById(int patId)
        {
            Patient p = new Patient();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    p = context.patients.Include(x => x.Account).SingleOrDefault(y => y.PatientId == patId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public static void CreatePatient(Patient p)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.patients.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdatePatient(Patient p)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Patient>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeletePatient(Patient p)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var p1 = context.patients.SingleOrDefault(c => c.PatientId == p.PatientId);
                    context.patients.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // CHƯA TEST SỢ LỖI
        /*public static List<Patient> GetMedicineByName(string name)
        {
            List<Patient> list = new List<Patient>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    list = context.patients.Include(p => p.Account).Where(a => a.Account.FullName.Equals(name)).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return list;
        }*/
    }
}
