using Microsoft.AspNetCore.Mvc;
using ClinicManagementAPI.Interfaces;
using ClinicManagementAPI.Models;
using ClinicManagementAPI.Exceptions;

namespace ClinicManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            try
            {
                var doctors = await _doctorService.GetDoctors();
                return Ok(doctors);
            }
            catch (NoDoctorsFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Doctor>> UpdateDoctorExperience(int id, [FromBody] int experience)
        {
            try
            {
                var updatedDoctor = await _doctorService.UpdateDoctorExperience(id, experience);
                return Ok(updatedDoctor);
            }
            catch (NoSuchDoctorException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("specialty/{specialty}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctorsBySpecialty(string specialty)
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsBySpecialty(specialty);
                return Ok(doctors);
            }
            catch (NoDoctorsFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
