using System.ComponentModel.DataAnnotations;
namespace PizzaOrderingAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public byte[]? PasswordHash { get; set; }
        [Required]
        //From GPT - Similar to HashKey.
        public byte[]? PasswordSalt { get; set; }
        //Added New Field Roles
        [Required]
        public string? Role { get; set; }
    }
}
