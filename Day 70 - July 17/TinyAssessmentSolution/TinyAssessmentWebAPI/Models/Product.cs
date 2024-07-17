using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TinyAssessmentWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [JsonPropertyName("imageUrl")]
        [Display(Name = "Image URL")]
        [Url]
        [System.ComponentModel.Description("Copy this URL and paste it into a new browser tab to view the image.")]
        public string ImageUrl { get; set; }
    }
}
