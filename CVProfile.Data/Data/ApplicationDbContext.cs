using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CVProfile.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace CVProfile.Data.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Skill> Skills { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add any additional model configurations here
        modelBuilder.Entity<Skill>()
            .HasIndex(s => s.Name)
            .IsUnique();

        modelBuilder.Entity<Project>()
            .HasIndex(p => p.Name)
            .IsUnique();

        // Configure required properties
        modelBuilder.Entity<Skill>()
            .Property(s => s.Name)
            .IsRequired();

        modelBuilder.Entity<Project>()
            .Property(p => p.Name)
            .IsRequired();
    }
} 