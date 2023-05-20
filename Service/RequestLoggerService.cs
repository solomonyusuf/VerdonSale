using Microsoft.AspNetCore.Http.Headers;
using System.ComponentModel.DataAnnotations;
using System.Net;
using VerdonSale.Data;
using VerdonSale.Models;
using static System.Net.WebRequestMethods;

namespace VerdonSale.Service
{
    public class RequestLoggerService
    {
        private readonly LoggerDbContext _context;
        private readonly IHttpContextAccessor _acc;
        public RequestLoggerService(LoggerDbContext context, IHttpContextAccessor acc)
        {

            _context = context;
            _acc = acc;
        }

        public async void Log(string action, string response)
        {
            var seet = (_acc.HttpContext.Connection.RemoteIpAddress);
            var input = new RequestLogger()
            {
                RequestId = Guid.NewGuid(),
                UserId = _acc.HttpContext.Session.GetString("UserId"),
                UserRole = _acc.HttpContext.Session.GetString("UserRole"),
                IPAddress = $"{seet}:{seet.Address} - {seet.AddressFamily}",
                Response = response,
                Actions = action

            };
            await _context.Requests.AddAsync(input);
            await _context.SaveChangesAsync();
            Console.WriteLine(input);
        }
    }
}
