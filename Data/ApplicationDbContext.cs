using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using VerdonSale.Models;
using VerdonSale.Seeders;
using VerdonSale.Service;

namespace VerdonSale.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreatedAsync();
            if (Database.GetPendingMigrationsAsync().Result.Count() > 0)
                Database.MigrateAsync();
        }

        public DbSet<AppUser> User { get; set; }
        public DbSet<IdentityRole> Role { get; set; }
        public DbSet<IdentityUserRole<string>> UserRole { get; set; }
        public DbSet<WordOfTheDay> WordOfTheDays { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<RequestLogger> Requests { get; set; }
        //Sales Db Context - Apply models to DB using single Dbcontext
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductCart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Order> Orders { get; set; }

        //Wallet Db Context - Apply models to DB using single Dbcontext
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ATMCard> ATMCards { get; set; }

       
    }
}