using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
	public class scientifictools
	{
        [Key]
        public int sci_id { get; set; }
        public string sci_name { get; set; }
        public string? sci_price { get; set; }
        public string? sci_description { get; set; }
        public string? sci_image { get; set; }
    }
}
