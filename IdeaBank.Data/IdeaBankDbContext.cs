using IdeaBank.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdeaBank.Data;

public class IdeaBankDbContext(DbContextOptions<IdeaBankDbContext> options) : DbContext(options)
{
    public DbSet<Idea> Ideas { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<IdeaComponent> IdeaComponents { get; set; }
    public DbSet<IdeaHelper>  IdeaHelpers { get; set; }
    public DbSet<IdeaSector> IdeaSectors { get; set; }
    public DbSet<IdeaPlace> IdeaPlaces { get; set; }
    public DbSet<IdeaUser> IdeaUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdeaSector>()
            .HasKey(x => new
            {
                x.IdeaId, x.SectorId
            });
        modelBuilder.Entity<IdeaHelper>()
            .HasKey(x => new
            {
                x.IdeaId, x.UserId
            });
        modelBuilder.Entity<IdeaPlace>()
            .HasKey(x => new
            {
                x.IdeaId, x.PlaceId
            });
        modelBuilder.Entity<IdeaUser>()
            .HasKey(x => new
            {
                x.IdeaId, x.UserId
            });
        modelBuilder.Entity<IdeaComponent>()
            .HasKey(x => new
            {
                x.IdeaId, x.ComponentId
            });
        modelBuilder.Entity<Idea>()
            .HasOne(i => i.Creator)
            .WithMany(i => i.CreatedIdeas)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}