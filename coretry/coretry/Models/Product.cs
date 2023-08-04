
using System.ComponentModel.DataAnnotations;


namespace coretry.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Description is required")]
        public string? Description { get; set; }
        public string? Type { get; set; }
        public bool Isavailable { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string? Deliverable { get; set; }
    }
}
