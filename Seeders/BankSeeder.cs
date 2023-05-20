using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VerdonSale.Data;
using VerdonSale.Models;

namespace VerdonSale.Seeders
{
    public class BankSeeder
    {
        public static void SeedBanks(ApplicationDbContext _db)
        {
            var banks = new List<string>
            {
                "Gurantee Trust Bank [GTB]",
                "First Bank of Nigeria [FBN]",
                "United Bank of Africa [UBA]",
                "Zenith Bank of Nigeria [ZBN]",
                "Union Bank of Nigeria [UBN]",
                "Skye Bank of Nigeria [SBN]",
                "Keystone Bank of Nigeria [KBN]",
                "Access Bank of Nigeria [ABN]",
                "Stanbic Bank of Nigeria [SBN]",
                "First City Monument Bank of Nigeria [ZBN]"
            };
            foreach (var bank in banks)
            {
                if (_db.Banks.Any(x=> x.BankName.Equals(bank)) == false)
                {
                    var data = new Bank() { BankName = bank };
                    _db.Banks.Add(data);
                    _db.SaveChanges();
                }
            }
        }

    }
}
