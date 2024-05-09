using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
	public class educationevents
	{
        [Key]
        public int event_id { get; set; }
        public string event_name { get; set; }
        public string? event_date { get; set; }
        public string? event_time { get; set; }
        public string? event_location { get; set; }
        public string? event_teacher { get; set; }
        public string? event_image { get; set; }
        public string? event_doctorimg { get; set; }
    }
}
