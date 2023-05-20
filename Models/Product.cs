using System.ComponentModel.DataAnnotations;

namespace VerdonSale.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public string ProductName { get; set; }
        public List<ProductImage> Images { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public long Available { get; set; }
        public double Price { get; set; }
        public string Tag { get; set; }
        public DateTime Stamp { get; set; }
        public Product()
        {
            Stamp = DateTime.Now;
            Images = new List<ProductImage>();
        }
    }
}
