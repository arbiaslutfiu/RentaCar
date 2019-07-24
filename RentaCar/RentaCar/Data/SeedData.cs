using Microsoft.AspNetCore.Identity;
using RentaCar.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Data
{
    public class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(SD.NormalEndUser).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = SD.NormalEndUser;
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync(SD.AdminEndUser).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = SD.AdminEndUser;
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
            
            //roli per Web Administrator
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {          //Web Admin(Supreeme) user admin@localhost : Admin123!
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";

                IdentityResult result = userManager.CreateAsync(user, "Admin123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }       
        }
    }
}