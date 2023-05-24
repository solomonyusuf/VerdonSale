using Microsoft.AspNetCore.Identity;
using System.Reactive.Subjects;
using VerdonSale.Models;

namespace VerdonSale.Service
{
    public class UserService
    {
        #nullable disable

        private readonly IHttpContextAccessor _http;
        private readonly UserManager<AppUser> _userManager;

        public UserService(IHttpContextAccessor http, 
                            UserManager<AppUser> userManager)
        {
            _http = http;
            _userManager = userManager;
        }

        public async Task<AppUser> GetUser()
        {
            var name = _http.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(name);
           
            return user;
        }

       

    }
}
