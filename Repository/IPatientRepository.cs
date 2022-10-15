using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatient();
        Patient GetPatientById(int id);
        void CreatePatient(Patient p);
        void UpdatePatient(Patient p);
        void DeletePatient(Patient p);
        
    }
}
