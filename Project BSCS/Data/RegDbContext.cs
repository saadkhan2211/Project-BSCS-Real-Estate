
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_BSCS.Models;

namespace Project_BSCS.Data
{
    public class RegDbContext : IdentityDbContext<ApplicationUser>
    {
        public RegDbContext(DbContextOptions<RegDbContext> options) : base(options)
        {

        }
    }
}
