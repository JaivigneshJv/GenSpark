﻿using ClinicManagementDALLibrary;
using ClinicManagementModelLibrary;

namespace ClinicManagementBLLibrary
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<int, Patient> _patientRepository;

        public PatientService()
        {
            _patientRepository = new PatientRepository();
        }

        public int AddPatient(Patient patient)
        {
            Patient added = _patientRepository.Add(patient);
            return added != null ? added.Id : -1;
        }

        public Patient DeletePatient(int id)
        {
            return _patientRepository.Delete(id);
        }

        public List<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetPatientById(int id)
        {
            return _patientRepository.Get(id);
        }

        public Patient UpdatePatient(Patient patient)
        {
            return _patientRepository.Update(patient);
        }
    }
}
