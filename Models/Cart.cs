using System.ComponentModel.DataAnnotations;

namespace VerdonSale.Models
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; }
        public string AppUserId { get; set; }
        public DateTime Stamp { get; set; }

        public Cart()
        {
            Stamp = DateTime.Now;
        }


    }
}
