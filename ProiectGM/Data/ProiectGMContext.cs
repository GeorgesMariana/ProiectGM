using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectGM.Models;

namespace ProiectGM.Data
{
    public class ProiectGMContext : DbContext
    {
        public ProiectGMContext (DbContextOptions<ProiectGMContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectGM.Models.Artwork> Artwork { get; set; } = default!;

        public DbSet<ProiectGM.Models.Author>? Author { get; set; }

        public DbSet<ProiectGM.Models.Department>? Department { get; set; }

        public DbSet<ProiectGM.Models.Exhibition>? Exhibition { get; set; }

        public DbSet<ProiectGM.Models.Visitor>? Visitor { get; set; }
    }
}
