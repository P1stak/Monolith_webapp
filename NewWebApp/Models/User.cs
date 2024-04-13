using Microsoft.AspNetCore.Identity;

namespace NewWebApp.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}