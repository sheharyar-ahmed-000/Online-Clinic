using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
	public class client
	{
		[Key]
		public int client_id { get; set; }
		public string client_name { get; set; }
		public string? client_number { get; set; }
		public string client_email { get; set; }
		public string? client_password { get; set; }
		public string? client_country { get; set; }
		public string? client_city { get; set; }
		public string? client_gender { get; set; }
		public string? client_image { get; set; }
		public string? client_eventname { get; set; }
		public string? client_eventdate { get; set; }

	}
}
