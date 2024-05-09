using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
    public class bussinesstransaction
    {
        [Key]
        public int bussiness_id { get; set; }
        public string? TransactionDate { get; set; }
        public string? Sector { get; set; } // Medicine, Education,  Machines
        public string? ProductName { get; set; }
        public string? Amount { get; set; }

    }
}
