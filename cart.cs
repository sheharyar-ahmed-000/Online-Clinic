using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
    public class cart
    {
        [Key]

        public int cart_id { get; set; }
        public string? cart_name { get; set; }
        public int cart_qty { get; set; }
        public int? cart_price { get; set; }
        public int? cart_bill { get; set; }
        public string? cart_img { get; set; }
    }
}
