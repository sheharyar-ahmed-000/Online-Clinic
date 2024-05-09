using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
    public class contact
    {
        [Key]
        public int contact_id { get; set; }
        public string? contact_name { get; set; }
        public string? contact_email { get; set; }
        public string? contact_subject { get; set; }
        public string? contact_message { get; set; }
    }
}
