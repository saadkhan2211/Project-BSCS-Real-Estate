using Project_BSCS.Data;
using System.ComponentModel.DataAnnotations;

namespace Project_BSCS.Models
{
    public class Property
    {
        public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        public string? PropertyImageUrl { get; set; }
        [Required] public string Location { get; set; }
        [Required] public string City { get; set; }
        [Required] public double Area { get; set; }
        [Required] public int Bedroom { get; set; }
        [Required] public int Bathroom { get; set; }
        [Required] public int Floors { get; set; }
        [Required] public double Price { get; set; }
        [Required] public string Hospital { get; set; }
        [Required] public string Institute { get; set; }
        [Required] public string Hotel { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string ContactNumber { get; set; }
        [Required] public IFormFile PropertyImage { get; set; }
        [Required] public IFormFileCollection PropertyImages { get; set; }
        public List<PropertyGallery>? Gallery { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
