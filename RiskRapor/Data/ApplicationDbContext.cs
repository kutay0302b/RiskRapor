using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RiskRapor.Models;

namespace RiskRapor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Veritabanı tabloları
        public DbSet<Anlasmalar> Anlasmalar { get; set; }
        public DbSet<IsKonulari> IsKonulari { get; set; }
        public DbSet<Firmalar> Firmalar { get; set; }
    }
}
