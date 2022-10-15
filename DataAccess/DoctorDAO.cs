using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DoctorDAO
    {
        public static List<Doctor> GetDoctor()
        {
            var listDoctor = new List<Doctor>();

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    listDoctor = context.doctors.ToList();
                    if (listDoctor.Count == 0)
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listDoctor;
        }

        public static Doctor FindDoctorById(int docId)
        {
            Doctor d = new Doctor();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    d = context.doctors.SingleOrDefault(x => x.DoctorId == docId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return d;
        }

        public static void CreateDoctor(Doctor d)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.doctors.Add(d);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateDoctor(Doctor d)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Doctor>(d).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteDoctor(Doctor d)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var p1 = context.doctors.SingleOrDefault(c => c.DoctorId == d.DoctorId);
                    context.doctors.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
