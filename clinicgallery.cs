using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
    public class clinicgallery
    {
        [Key]
        public int gallery_id { get; set; }
        public string? gallery_img { get; set; }
    }
}
