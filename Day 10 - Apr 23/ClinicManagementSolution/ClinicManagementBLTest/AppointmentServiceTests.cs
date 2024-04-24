using NUnit.Framework;
using ClinicManagementBLLibrary;
using ClinicManagementModelLibrary;
using System;
using System.Collections.Generic;
using ClinicManagementBLLibrary.Exceptions;

namespace ClinicManagementBLTest
{
    public class AppointmentServiceTests
    {
        private AppointmentService _service;

        [SetUp]
        public void Setup()
        {
            _service = new AppointmentService();
        }

        [Test]
        public void AddAppointment_NullAppointment_ThrowsException()
        {
            Assert.Throws<AppointmentConflictException>(() => _service.AddAppointment(null));
        }

        [Test]
        public void AddAppointment_ValidAppointment_ReturnsId()
        {
            var appointment = new Appointment(1, 1, DateTime.Now, "Test");

            var result = _service.AddAppointment(appointment);

            Assert.That(result, Is.EqualTo(appointment.Id));
        }

        [Test]
        public void DeleteAppointment_ValidId_ReturnsAppointment()
        {
            var appointment = new Appointment(1, 1, DateTime.Now, "Test");

            _service.AddAppointment(appointment);
            var result = _service.DeleteAppointment(appointment.Id);

            Assert.That(result, Is.EqualTo(appointment));
        }

        [Test]
        public void GetAllAppointments_ReturnsListOfAppointments()
        {
            var appointments = new List<Appointment> { new Appointment(1, 1, DateTime.Now, "Test"), new Appointment(2, 2, DateTime.Now, "Test") };

            foreach (var appointment in appointments)
            {
                _service.AddAppointment(appointment);
            }

            var result = _service.GetAllAppointments();

            Assert.That(result, Is.EqualTo(appointments));
        }

        [Test]
        public void GetAppointmentById_ValidId_ReturnsAppointment()
        {
            var appointment = new Appointment(1, 1, DateTime.Now, "Test");

            _service.AddAppointment(appointment);
            var result = _service.GetAppointmentById(appointment.Id);

            Assert.That(result, Is.EqualTo(appointment));
        }

        [Test]
        public void UpdateAppointment_NullAppointment_ThrowsException()
        {
            Assert.Throws<AppointmentConflictException>(() => _service.UpdateAppointment(null));
        }
    }
}
