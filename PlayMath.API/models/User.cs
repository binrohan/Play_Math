using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PlayMath.API.Models
{
    public class User : IdentityUser
    {
        public ICollection<Article> Articles { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public bool ArticleSubscribed { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}