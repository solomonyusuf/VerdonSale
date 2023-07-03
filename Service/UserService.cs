using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reactive.Subjects;
using VerdonSale.Data;
using VerdonSale.Models;

namespace VerdonSale.Service
{
    public class UserService
    {
        #nullable disable

        private readonly IHttpContextAccessor _http;
        private readonly ApplicationDbContext _db;

        public UserService(IHttpContextAccessor http,
                            ApplicationDbContext db)
        {
            _http = http;
            _db = db;
        }

        public async Task<AppUser> GetUser()
        {  
            return await _db.User.Where(x => x.Email.Equals(_http.HttpContext.User.Identity.Name)).SingleAsync();
        }

       

    }
}
