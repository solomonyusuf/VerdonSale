using System.ComponentModel.DataAnnotations;

namespace VerdonSale.Models
{
    public class ATMCard
    {
        [Key]
        [Required]
        public Guid ATMCardId { get; set; }
        public string AppUserId { get; set; }
        public string Digit { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public string CardType { get; set; }
        public string Bank { get; set; }
        public DateTime Stamp { get; set; }

        public ATMCard()
        {
            Stamp = DateTime.Now;
        }
    }
}
