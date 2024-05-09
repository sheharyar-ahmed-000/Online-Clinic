using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
	public class admin
	{
		[Key]
		public int admin_id { get; set; }
		public string admin_name { get; set; }
		public string admin_email { get; set; }
		public string admin_password { get; set; }
		public string? admin_image { get; set; }
	}
}
