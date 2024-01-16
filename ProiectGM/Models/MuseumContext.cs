using Microsoft.EntityFrameworkCore;
using ProiectGM.Models;  // Asigură-te că adaugi această referință
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProiectGM.Data
{
    public class MuseumContext : DbContext
    {
        public MuseumContext(DbContextOptions<MuseumContext> options) : base(options) { }

        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relații existente pentru Artwork și Exhibition
            modelBuilder.Entity<Artwork>()
                .HasOne(a => a.Exhibition)
                .WithMany(e => e.Artworks)
                .HasForeignKey(a => a.ExhibitionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Exhibition>()
                .HasOne(e => e.Department)
                .WithOne(d => d.Exhibition)
                .HasForeignKey<Department>(d => d.ExhibitionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relație între Artwork și Author
            modelBuilder.Entity<Artwork>()
                .HasOne(a => a.Author)
                .WithMany(author => author.Artworks)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relație între Exhibition și Visitor
            modelBuilder.Entity<Exhibition>()
                .HasMany(e => e.Visitors)
                .WithMany(v => v.ExhibitionsAttended)
                .UsingEntity(j => j.ToTable("ExhibitionVisitor"));
        }
    }
}
