using Microsoft.EntityFrameworkCore;
using WCQuatar2k22.Domain.Models;

namespace WCQuatar2k22.Domain.Domain
{
    public class Context:DbContext
    {
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Stadion> Stadion { get; set; }
        public DbSet<Grupa> Grupa { get; set; }
        public DbSet<Utakmica> Utakmica { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=WCQuatar2k22; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utakmica>().HasOne(u => u.Stadion)
                .WithMany().HasForeignKey(u => u.StadionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Utakmica>().HasOne(u => u.Domacin)
                .WithMany().HasForeignKey(u => u.DomacinId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Utakmica>().HasOne(u => u.Gost)
                .WithMany().HasForeignKey(u => u.GostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Drzava>().HasOne(d=>d.Grupa)
                .WithMany(g=>g.Drzave).HasForeignKey(u => u.GrupaId)
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}