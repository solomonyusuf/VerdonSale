using System.ComponentModel.DataAnnotations;

namespace VerdonSale.Models
{
    public class ProductImage
    {
        [Key]
        public Guid ProductImageId { get; set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Stamp { get; set; }

        public ProductImage()
        {
            Stamp = DateTime.Now;
        }
    }
}
