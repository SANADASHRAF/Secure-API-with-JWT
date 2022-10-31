using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace TestApiJwt.Model
{
    public class Applicationuser:IdentityUser
    {       
        [Required]
        public string? firstname { get; set; }
        [Required]
        public string? lastname { get; set; }
    }
}
