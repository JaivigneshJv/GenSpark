using ClinicManagementAPI.Interfaces;
using ClinicManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementAPI.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicManagementDbContext _context;
        public DoctorRepository(ClinicManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            var existingDoctor = await _context.Doctors.FindAsync(doctor.Id);
            if (existingDoctor != null)
            {
                existingDoctor.Experience = doctor.Experience;
                await _context.SaveChangesAsync();
            }
            return existingDoctor;
        }
        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecialty(string specialty)
        {
            return await _context.Doctors.Where(d => d.Speciality.ToLower().Contains(specialty.ToLower())).ToListAsync();
        }
        public async Task<Doctor> GetDoctorById(int id) 
        {
            return await _context.Doctors.FindAsync(id);
        }
    }
}
