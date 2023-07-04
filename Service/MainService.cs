using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reactive.Subjects;
using VerdonSale.Data;
using VerdonSale.Models;
using VerdonSale.Shared;
using static System.Net.WebRequestMethods;

namespace VerdonSale.Service
{
    public class MainService
    {
        public BehaviorSubject<List<CartProduct>> cart = new BehaviorSubject<List<CartProduct>>(new List<CartProduct>());
        public BehaviorSubject<int> Cart = new BehaviorSubject<int>(0);
        public BehaviorSubject<AppUser> User = new BehaviorSubject<AppUser>(new AppUser());
        private readonly SalesDbContext _db;
        private readonly ApplicationDbContext _app;
        private readonly UserService _user;
        private readonly IHttpContextAccessor _http;
        private readonly UserManager<AppUser> _userMananager;
        


        public MainService
            (SalesDbContext db,
             ApplicationDbContext app,
            UserManager<AppUser> userMananager,
            UserService user,
            IHttpContextAccessor http)
        {
            _db = db;
            _app = app;
            _userMananager = userMananager;
            _user = user;
            _http = http;
        }

        public async Task<string> CheckCart()
        {
         
            var entity = await _user.GetUser();
            try
            {
                if (entity != null)
                {
                    if (entity.CartId.ToString() == "00000000-0000-0000-0000-000000000000" && entity != null)
                    {
                        var cartEntity = new ProductCart() { AppUserId = entity.Id };
                        await _db.Carts.AddAsync(cartEntity);
                        await _db.SaveChangesAsync();
                        entity.CartId = cartEntity.CartId;
                        _app.User.Update(entity);
                        await _app.SaveChangesAsync();


                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return entity.CartId.ToString();
        }

        public async Task<List<CartProduct>> FetchCart()
        {
            var ID = await CheckCart();
            return await _db.CartProducts.Where(x => x.CartId == Guid.Parse(ID)).ToListAsync(); 
        }


        public async Task AddToCart(Product product, string UserID)
        {
            try
            {
                var ID = await CheckCart();
                var entity = new CartProduct()
                {
                    ProductId = product.ProductId,
                    CartId = Guid.Parse(ID),
                    UserId = UserID,
                    Image = product.Images.First().ImagePath,
                    Size = "general",
                    Color = "general",
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = 1,
                };

                await _db.CartProducts.AddAsync(entity);
                await _db.SaveChangesAsync();
               

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        } 
        public async Task<Guid> CheckProduct(Product product, string Id)
        {
            var ID = new Guid();
            try
            {
               if( _db.CartProducts.Count() > 0)
                {
                    var query = await _db.CartProducts.Where(c => c.ProductId == product.ProductId && c.UserId == Id).SingleAsync();
                    ID = query.ProductId;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return ID;
        }

       
    }

    
}
