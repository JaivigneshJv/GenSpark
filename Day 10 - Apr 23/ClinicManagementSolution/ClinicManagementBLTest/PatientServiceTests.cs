using NUnit.Framework;
using ClinicManagementBLLibrary;
using ClinicManagementModelLibrary;
using ClinicManagementBLLibrary.Exceptions;
using System;

namespace ClinicManagementBLTest
{
    public class PatientServiceTests
    {
        private PatientService _service;

        [SetUp]
        public void Setup()
        {
            _service = new PatientService();
        }

        [Test]
        public void AddPatient_NullPatient_ThrowsException()
        {
            Patient nullPatient = null;
            Assert.Throws<PatientNotFoundException>(() => _service.AddPatient(nullPatient));
        }

        [Test]
        public void AddPatient_ValidPatient_ReturnsId()
        {
            var patient = new Patient("John", DateTime.Now, "Doe", "1234567890") { Id = 1 };

            var result = _service.AddPatient(patient);

            Assert.That(result, Is.EqualTo(patient.Id));
        }

        [Test]
        public void DeletePatient_ValidId_ReturnsPatient()
        {
            var patient = new Patient("John", DateTime.Now, "Doe", "1234567890") { Id = 1 };

            _service.AddPatient(patient);
            var result = _service.DeletePatient(patient.Id);

            Assert.That(result, Is.EqualTo(patient));
        }

        [Test]
        public void GetPatientById_ValidId_ReturnsPatient()
        {
            var patient = new Patient("John", DateTime.Now, "Doe", "1234567890") { Id = 1 };

            _service.AddPatient(patient);
            var result = _service.GetPatientById(patient.Id);

            Assert.That(result, Is.EqualTo(patient));
        }

        [Test]
        public void UpdatePatient_NullPatient_ThrowsException()
        {
            Patient nullPatient = null;
            Assert.Throws<PatientNotFoundException>(() => _service.UpdatePatient(nullPatient));
        }

        [Test]
        public void UpdatePatient_ValidPatient_ReturnsUpdatedPatient()
        {
            var patient = new Patient("John", DateTime.Now, "Doe", "1234567890") { Id = 1 };

            _service.AddPatient(patient);
            var updatedPatient = new Patient("Jane", DateTime.Now, "Doe", "1234567890") { Id = 1 };

            var result = _service.UpdatePatient(updatedPatient);

            Assert.That(result, Is.EqualTo(updatedPatient));
        }
        

        [Test]
        public void DeletePatient_InvalidId_ThrowsException()
        {
            Assert.Throws<PatientNotFoundException>(() => _service.DeletePatient(999));
        }


        [Test]
        public void AddPatient_ValidPatient_IncreasesCount()
        {
            var patient = new Patient("John", DateTime.Now, "Doe", "1234567890") { Id = 1 };
            var initialCount = _service.GetAllPatients().Count;

            _service.AddPatient(patient);

            Assert.That(_service.GetAllPatients().Count, Is.EqualTo(initialCount + 1));
        }

    }
}
