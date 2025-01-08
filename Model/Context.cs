using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using taskinterview.Model;

public class AppDbContext : DbContext
{
    public DbSet<Empolyee> Employees { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Empolyee>().HasData(
        new Empolyee { Id = 1, Name = "Sherin", Email = "sherin.doe@email.com", Phone = "133333337890", Address = "123 tt St" },
            new Empolyee { Id = 2, Name = "sara", Email = "sara.doe@email.com", Phone = "09833321", Address = "456 Eff St" },
            new Empolyee { Id = 3, Name = "abdo", Email = "abdo.doe@email.com", Phone = "333333335", Address = "789 Off St" }
        );
    }
}
