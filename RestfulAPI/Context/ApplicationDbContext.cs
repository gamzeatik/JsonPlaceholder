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
        DbSet<Album> Albums { get; set; }
        DbSet<Photo> Photos { get; set; }
        DbSet<Todo> Todos { get; set; }
        DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Address <-> Geo: One-to-One relationship
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Geo)
                .WithOne(g => g.Address)
                .HasForeignKey<Address>(a => a.GeoId)
                .OnDelete(DeleteBehavior.Cascade);

            // User <-> Address: One-to-One relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User <-> Company: One-to-One relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithOne(c => c.User)
                .HasForeignKey<Company>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            // User <-> Album: One-to-Many relationship
            modelBuilder.Entity<Album>()
                .HasOne(a => a.User)
                .WithMany(u => u.Albums)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Album <-> Photo: One-to-Many relationship
            modelBuilder.Entity<Photo>()
                .HasOne(p => p.Album)
                .WithMany(a => a.Photos)
                .HasForeignKey(p => p.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

            // User <-> Todo: One-to-Many relationship
            modelBuilder.Entity<Todo>()
                .HasOne(t => t.User)
                .WithMany(u => u.Todos)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            // Post <-> Comment: One-to-Many relationship
            modelBuilder.Entity<Comment>()
                .HasOne(p => p.Post)
                .WithMany(u => u.Comments)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
