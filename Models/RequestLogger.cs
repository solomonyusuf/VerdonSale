using Microsoft.AspNetCore.Http.Headers;
using System.ComponentModel.DataAnnotations;
using System.Net;
using VerdonSale.Data;
using static System.Net.WebRequestMethods;

namespace VerdonSale.Models
{
    public class RequestLogger
    {
        [Key]
        public Guid RequestId { get; set; }
        public string? UserId { get; set; }
        public string? UserRole { get; set; }
        public string? IPAddress { get; set; }
        public string? Response { get; set; }
        public string? Actions { get; set; }
        public DateTime Stamp { get; set; }

        public RequestLogger()
        {
            Stamp = DateTime.Now;
        }
    }
}
