using Microsoft.EntityFrameworkCore;
using RestfulAPI.Model;

namespace RestfulAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<Post> Posts { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Geo> Geos { get; set; }
    }
}
