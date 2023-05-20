using System.ComponentModel.DataAnnotations;

namespace VerdonSale.Models
{
    public class ProductReview
    {
        [Key]
        public Guid ProductReviewId { get; set; }
        public Guid ProductId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Stamp { get; set; }
        public ProductReview()
        {
            Stamp = DateTime.Now;
         
        }
    }
}
