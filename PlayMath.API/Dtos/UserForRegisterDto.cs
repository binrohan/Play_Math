using System;

namespace PlayMath.API.Dtos
{
    public class UserForRegisterDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Joined { get; set; }
    

        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        public UserForRegisterDto(){
            Joined = DateTime.Now;
            EmailConfirmed = true;
            PhoneNumberConfirmed = false;
        }
    }
}