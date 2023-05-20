using System.ComponentModel.DataAnnotations;

namespace VerdonSale.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionId { get; set; }
        public Guid WalletId { get; set; }
        public string AppUserId { get; set; }
        public Guid OrderId { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
        public bool Confirmed { get; set; }
        public DateTime Stamp { get; set; }

        public Transaction()
        {
            Stamp = DateTime.Now;
        }

    }
}
