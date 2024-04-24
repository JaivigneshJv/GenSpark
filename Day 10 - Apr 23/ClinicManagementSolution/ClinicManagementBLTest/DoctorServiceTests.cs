using NUnit.Framework;
using ClinicManagementBLLibrary;
using ClinicManagementModelLibrary;
using ClinicManagementBLLibrary.Exceptions;
using System;

namespace ClinicManagementBLTest
{
    public class DoctorServiceTests
    {
        private DoctorService _service;

        [SetUp]
        public void Setup()
        {
            _service = new DoctorService();
        }

        [Test]
        public void AddDoctor_NullDoctor_ThrowsException()
        {
            Doctor nullDoctor = null;
            Assert.Throws<DoctorNotFoundException>(() => _service.AddDoctor(nullDoctor));
        }

        [Test]
        public void AddDoctor_ValidDoctor_ReturnsId()
        {
            var doctor = new Doctor("John", "Doe", "Cardiology", 1);

            var result = _service.AddDoctor(doctor);

            Assert.That(result, Is.EqualTo(doctor.Id));
        }

        [Test]
        public void DeleteDoctor_ValidId_ReturnsDoctor()
        {
            var doctor = new Doctor("John", "Doe", "Cardiology", 1);

            _service.AddDoctor(doctor);
            var result = _service.DeleteDoctor(doctor.Id);

            Assert.That(result, Is.EqualTo(doctor));
        }

        [Test]
        public void GetAllDoctors_ReturnsListOfDoctors()
        {
            var doctors = new Doctor[] { new Doctor("John", "Doe", "Cardiology", 1), new Doctor("Jane", "Doe", "Neurology", 2) };

            foreach (var doctor in doctors)
            {
                _service.AddDoctor(doctor);
            }

            var result = _service.GetAllDoctors();

            Assert.That(result, Is.EqualTo(doctors));
        }

        [Test]
        public void GetDoctorById_ValidId_ReturnsDoctor()
        {
            var doctor = new Doctor("John", "Doe", "Cardiology", 1);

            _service.AddDoctor(doctor);
            var result = _service.GetDoctorById(doctor.Id);

            Assert.That(result, Is.EqualTo(doctor));
        }

        [Test]
        public void UpdateDoctor_NullDoctor_ThrowsException()
        {
            Doctor nullDoctor = null;
            Assert.Throws<DoctorNotFoundException>(() => _service.UpdateDoctor(nullDoctor));
        }
      

        [Test]
        public void DeleteDoctor_InvalidId_ThrowsException()
        {
            Assert.Throws<DoctorNotFoundException>(() => _service.DeleteDoctor(999));
        }

        [Test]
        public void AddDoctor_ValidDoctor_IncreasesCount()
        {
            var doctor = new Doctor("John", "Doe", "Cardiology", 1);
            var initialCount = _service.GetAllDoctors().Count;

            _service.AddDoctor(doctor);

            Assert.That(_service.GetAllDoctors().Count, Is.EqualTo(initialCount + 1));
        }


    }
}
