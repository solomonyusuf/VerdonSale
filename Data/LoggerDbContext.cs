using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using VerdonSale.Models;
using VerdonSale.Seeders;
using VerdonSale.Service;

namespace VerdonSale.Data
{
    public class LoggerDbContext : DbContext
    {
        public LoggerDbContext(DbContextOptions<LoggerDbContext> options)
            : base(options)
        {
     
        }

        public DbSet<RequestLogger> Requests { get; set; }
        

       
    }
}