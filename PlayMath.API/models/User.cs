using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PlayMath.API.Models
{
    public class User : IdentityUser
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}