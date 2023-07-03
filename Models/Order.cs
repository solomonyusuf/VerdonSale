using System.ComponentModel.DataAnnotations;

namespace VerdonSale.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid CartId { get; set; }
        public string AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string OrderNote { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postalcode { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }
        public bool Confirmed { get; set; }
        public bool Payment { get; set; }
        public bool Delivered { get; set; }
        public DateTime Stamp { get; set; }

        public Order()
        {
            Stamp = DateTime.Now;
        }
    }
}
