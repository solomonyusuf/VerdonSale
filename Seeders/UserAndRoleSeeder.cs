using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VerdonSale.Data;
using VerdonSale.Models;

namespace VerdonSale.Seeders
{
    public class UserAndRoleSeeder
    {
        public static void SeedData(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

       
        public static void SeedUsers(UserManager<AppUser> userManager)
        {

            try
            {

                if (userManager.FindByNameAsync
                       ("olafire03@gmail.com").Result == null)
                {
                    var user = new AppUser();
                    user.UserName = "olafire03@gmail.com";
                    user.Email = "olafire03@gmail.com";
                    user.EmailConfirmed = true;
                    IdentityResult result = userManager.CreateAsync
                    (user, "Solomon12!").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Admin").Wait();
                    }
                }
                if (userManager.FindByNameAsync
                       ("user@gmail.com").Result == null)
                {
                    var user = new AppUser();
                    user.UserName = "user@gmail.com";
                    user.Email = "user@gmail.com";
                    user.EmailConfirmed = true;
                    IdentityResult result = userManager.CreateAsync
                    (user, "Solomon12!").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "User").Wait();
                    }
                }

                
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }



        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            try 
            {
                if (!roleManager.RoleExistsAsync
                ("User").Result)
                {
                    var role = new IdentityRole();
                    role.Name = "User";
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }

                if (!roleManager.RoleExistsAsync
                   ("Manager").Result)
                {
                    var role = new IdentityRole();
                    role.Name = "HOC";
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }


                if (!roleManager.RoleExistsAsync
                    ("Admin").Result)
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
