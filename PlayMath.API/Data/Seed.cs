using System.Collections.Generic;
using System.Linq;
using PlayMath.API.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace PlayMath.API.Data
{
    public class Seed
    {
        public static void SeedUsers(UserManager<User> userManager, RoleManager<Role> roleManager)
        {

            if(!userManager.Users.Any())
            {

                // create some roles
                var roles = new List<Role>
                {
                    new Role{Name = "Admin", Id = "1"},
                    new Role{Name = "Writer", Id = "2"},
                    new Role{Name = "Reader", Id = "3"}
                };
                //Adding the roles into the database table
                foreach (var role in roles)
                {
                    roleManager.CreateAsync(role).Wait();
                }
                
                

                //create admin user
                var adminUser = new User
                {
                    UserName = "Admin",
                    Email = "admin@mail.com"
                };

                var result = userManager.CreateAsync(adminUser, "password").Result;

                if(result.Succeeded)
                {
                    var admin = userManager.FindByNameAsync("Admin").Result;
                    userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }





        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt){
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}




// [
//   '{{repeat(18)}}',
//   {
    
//     UserName: '{{firstName()}} {{surname()}}',
//     Email: '{{email()}}',
//     Password: 'password',
//     Gender: '{{gender()}}',
//     Joined: '{{date(new Date(2014, 0, 1), new Date(), "YYYY-MM-ddThh:mm:ss Z")}}',
//     Adrs_Local: '{{street()}}',
//     Adrs_City: '{{city()}}',
//     Adrs_Division: '{{state()}}',
//     Adrs_Country: '{{country()}}',
//     phone: '+880 {{phone()}}'
//   }
// ]