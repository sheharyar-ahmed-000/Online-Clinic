using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
	public class feedback
	{
		[Key]
		public int feedback_id { get; set; }
		public string feedback_name { get; set; }
		public string? feedback_email { get; set; }
		public string feedback_message { get; set; }

	}
}
