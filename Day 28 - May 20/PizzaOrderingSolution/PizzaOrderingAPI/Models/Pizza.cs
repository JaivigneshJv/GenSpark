using System.ComponentModel.DataAnnotations;

namespace PizzaOrderingAPI.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}