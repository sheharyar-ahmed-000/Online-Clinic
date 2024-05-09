using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
	public class medicines
	{
        [Key]
        public int med_id { get; set; }
        public string med_name { get; set; }
        public string? med_type { get; set; }
        public string? med_code { get; set; }
        public string? med_price { get; set; }
        public string? med_description { get; set; }
        public string? med_image { get; set; }
        public int medicinecat_id {  get; set; }
        public medicinecategory medicinecat { get; set; }

	}
}
