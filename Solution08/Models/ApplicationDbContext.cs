
using Microsoft.EntityFrameworkCore;

namespace Solution08.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed de deux catégories par défaut
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "PDF" },
                new Category { Id = 2, Name = "CD" }
            );

            // Items de base
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Title = "Algorithmique - Notions de base",
                    Description = "Manuel papier pour débuter en algorithmique",
                    PageCount = 320,                   // applicable aux livres/PDF
                    PublicationYear = 2021,
                    Price = 29.99f,
                    CategoryId = 1                     // PDF
                },
                new Item
                {
                    Id = 2,
                    Title = "Guide CSS",
                    Description = "Livret de références CSS",
                    PageCount = 120,
                    PublicationYear = 2019,
                    Price = 9.99f,
                    CategoryId = 1                     // PDF
                },
                new Item
                {
                    Id = 3,
                    Title = "Apache Tomcat/JBoss for Java EE",
                    Description = "Serveurs d'applications pour Java EE",
                    PublicationYear = 2024,
                    Price = 0.00f,
                    CategoryId = 2                     // CD
                }
            );
        }
    }
}
