using Microsoft.AspNetCore.Identity;

namespace Dot.Net.WebApi.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Fullname { get; set; }
    }
}