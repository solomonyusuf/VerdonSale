using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using VerdonSale.Data;

namespace VerdonSale.Models
{
    public class Wallet
    {
        [Key]
        public Guid WalletId { get; set; }
        public string AppUserId { get; set; }
        public double Balance { get; set; }
        public double Limit { get; set; }
        public DateTime Stamp { get; set; }
        public Wallet()
        {
            Stamp = DateTime.Now;
        }
        
    }
}
