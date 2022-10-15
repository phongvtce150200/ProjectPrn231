using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PatientRepository : IPatientRepository
    {
        public List<Patient> GetAllPatient() => PatientDAO.GetPatient();

        public Patient GetPatientById(int id) => PatientDAO.FindPatientById(id);

        public void CreatePatient(Patient p) => PatientDAO.CreatePatient(p);

        public void UpdatePatient(Patient p) => PatientDAO.UpdatePatient(p);

        public void DeletePatient(Patient p) => PatientDAO.DeletePatient(p);

        
    }
}
