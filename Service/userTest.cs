using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VerdonSale.Data;
using VerdonSale.Models;

namespace VerdonSale.Service
{
    public class userTest: ControllerBase
    {
        private ApplicationDbContext _db;
        public userTest(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("api/users")]
        public async Task<List<AppUser>> getUsers()
        {
            var users = await _db.User.ToListAsync();


            return users;
        }
    }
}
