using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
    public class teachers
    {
        [Key]
        public int teacher_id { get; set; }
        public string? teacher_name { get; set; }
        public string? teacher_img { get; set; }
    }
}
