using System.ComponentModel.DataAnnotations;

namespace ClinicManagementAPI.Models
{
    public class Doctor
    {
    
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Speciality { get; set; } 
        public string? Contact { get; set; } 
        public int Experience { get; set; }
    }
}