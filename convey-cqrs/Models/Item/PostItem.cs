using System.ComponentModel.DataAnnotations;

namespace convey_cqrs.Models.Item
{
    public class ItemPostDto
    {
        [Required]
        public string Upc { get; set; }
        [Required]
        public string Description { get; set; }
    }
}