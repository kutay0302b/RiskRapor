//using Microsoft.EntityFrameworkCore;
//using RiskRapor.Models; 

//namespace RiskRapor.Data
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }

//        // Veritabanı tabloları
//        public DbSet<Anlasmalar> Anlasmalar { get; set; }
//        public DbSet<IsKonulari> IsKonulari { get; set; }
//        public DbSet<Firmalar> Firmalar { get; set; }
//        public DbSet<MaliBilgiler> MaliBilgiler { get; set; }  // Yeni eklenen DbSet

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            // İlişki tanımlaması yapıyoruz
//            modelBuilder.Entity<MaliBilgiler>()
//                .HasOne(m => m.Anlasma)
//                .WithMany(a => a.MaliBilgiler)
//                .HasForeignKey(m => m.AnlasmaId);
//        }
//    }
//}
