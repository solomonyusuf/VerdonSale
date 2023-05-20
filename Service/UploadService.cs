using System;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VerdonSale.Models;
using VerdonSale.Service;

namespace VerdonSale.Services
{
    public class UploadService : ControllerBase
    {
        public readonly IConfiguration _config;
        public UploadService(IConfiguration config)
        {
       
            _config = config;

        }


        
        [AllowAnonymous]
        [HttpPost, DisableRequestSizeLimit]
        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        public async Task<string> UploadFile(IBrowserFile seed)
        {
            try
            {
       
                var file = seed.OpenReadStream(250000000);
                var folderName = Path.Combine("wwwroot", "StaticFiles");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                string result = "";
                if (file.Length > 0)
                {
                    var fileName = seed.Name;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    result = dbPath;
                }
                
                return result;
            }
            catch (Exception ex)
            {
               return $"{ex}";
            }
        }

       

    }

 }


       