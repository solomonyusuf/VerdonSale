using System.ComponentModel.DataAnnotations;

namespace VerdonSale.Models
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime Stamp { get; set; }

        public Contact()
        {
            Stamp = DateTime.Now;
        }

    }
}
