using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace homework_64_Atai.Models
{
    public class AppContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<TransJ> Transjs { get; set; }
        public DbSet<ServiceUsers> serviceUsers { get; set; }
        public DbSet<ServiceCompany> serviceCs { get; set; }
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
    }
}
