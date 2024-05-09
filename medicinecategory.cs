using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
	public class medicinecategory
	{
        [Key]
        public int medicinecat_id { get; set; }
        public string medicinecat_name { get; set; }
        public string? medicinecat_image { get; set; }
        public List<medicines> medicines { get; set; }
    }
}
