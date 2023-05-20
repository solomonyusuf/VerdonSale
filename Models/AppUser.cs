using Microsoft.AspNetCore.Identity;

namespace VerdonSale.Models
{
    public class AppUser: IdentityUser
    {
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postalcode { get; set; }
        public double WalletBalance { get; set; }

    }
}
