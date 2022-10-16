using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using api;
using Microsoft.AspNetCore.Identity;

public class PretparkContext : IdentityDbContext{
    public PretparkContext (DbContextOptions<PretparkContext> options): base(options){}
    public DbSet<api.Attractie> Attractie {get; set;} = default!;
    public DbSet<api.Gebruiker> Gebruiker {get; set;} = default!;

protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); 
        builder.Entity<Attractie>()
            .HasMany(p => p.GLikes)
            .WithMany(p => p.GelikteAttracties)
            .UsingEntity<Dictionary<string, object>>(
                "Like",
                j => j
                    .HasOne<Gebruiker>()
                    .WithMany()
                    .HasForeignKey("GebruikerId")
                    .HasConstraintName("FK_Likes_Gebruikers_GebruikerId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Attractie>()
                    .WithMany()
                    .HasForeignKey("AttractieId")
                    .HasConstraintName("FK_Likes_Attracties_AttractieId")
                    .OnDelete(DeleteBehavior.ClientCascade));
        builder.Entity<IdentityRole>().HasData(new IdentityRole(){Name = "Medewerker", NormalizedName = "MEDEWERKER"});
        builder.Entity<IdentityRole>().HasData(new IdentityRole(){Name = "Gebruiker", NormalizedName = "GEBRUIKER"});
    }
}
