using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
    public class scitwo
    {
        [Key]
        public int two_id { get; set; }
        public string two_name { get; set; }
        public string? two_price { get; set; }
        public string? two_des { get; set; }
        public string? two_img { get; set; }
    }
}
