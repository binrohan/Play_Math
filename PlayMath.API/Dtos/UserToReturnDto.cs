using System.Collections.Generic;

namespace PlayMath.API.Dtos
{
    public class UserToReturnDto
    {
        public string UserName { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }
}