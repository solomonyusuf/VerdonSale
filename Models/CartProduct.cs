using System.ComponentModel.DataAnnotations;

namespace VerdonSale.Models
{
    public class CartProduct
    {
        [Key]
        public Guid CartProductId { get; set; }
        public Guid CartId { get; set; }
        public string Image { get; set; }
        public string UserId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Stamp { get; set; }

        public CartProduct()
        {
            Stamp = DateTime.Now;
        }
    }
}
