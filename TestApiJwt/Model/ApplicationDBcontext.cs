using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TestApiJwt.Model
{
    public class ApplicationDBcontext:IdentityDbContext<Applicationuser>
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext>opptions):base(opptions)
        {
        }

    }
}
