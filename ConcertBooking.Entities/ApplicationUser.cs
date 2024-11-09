using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Identity:  membership program : Authentication- Credentials(Username & password) & Authorization(Access Right)

//Authentication
//Registration - : IdentityUser Class - Id(Guid), Username, Password, Email, Phone 
            //SignInManager - CHeck user Signin, User signin
            //UserManager - Store userdata in database , get user information , add role to user 
            //IdentityRole: Id, Name


namespace ConcertBooking.Entities
{
    public class ApplicationUser :IdentityUser
    {
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public string? Pincode { get; set; }
    }
}
