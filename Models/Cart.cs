using System.ComponentModel.DataAnnotations;

namespace VerdonSale.Models
{
    public class ProductCart
    {
        [Key]
        public Guid CartId { get; set; }
        public string AppUserId { get; set; }
        public DateTime Stamp { get; set; }

        public ProductCart()
        {
            Stamp = DateTime.Now;
        }


    }
}
