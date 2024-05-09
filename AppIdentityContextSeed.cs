using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class AppIdentityContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (userManager.Users.Any()) 
            {
                var user = new AppUser
                {
                    DisplayName = "Mahmoud Nasser",
                    Email = "mahmoud@gmail.com",
                    UserName = "nasser",
                    Address = new Address
                    {
                        FirstName = "mahmoud",
                        LastName = "nasser",
                        City = "tanta",
                        State = "tanta",
                        Street = "elhelw",
                        ZipCode = "30152"
                    }
                };
                await userManager.CreateAsync(user,"Password123!");
            }
        }
    }
}
