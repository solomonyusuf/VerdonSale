using System.ComponentModel.DataAnnotations;

namespace VerdonSale.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string Image { get; set; }
        public string CategoryName { get; set; }
        public DateTime Stamp { get; set; }

        public Category()
        {
            Stamp = DateTime.Now;
        }
    }
}
