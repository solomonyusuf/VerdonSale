using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using VerdonSale.Data;

namespace VerdonSale.Models
{
    public class Bank
    {
        [Key]
        public Guid BankId { get; set; }
        public string BankName { get; set; }
        public DateTime Stamp { get; set; }
        public Bank()
        {
            Stamp = DateTime.Now;
        }
        
    }
}
