using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Project>? Projects { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<ProgrammingLanguage>? ProgrammingLanguages { get; set; }
        public DbSet<Technology>? Technologies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Власник проєкту
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Owner) // Один студент
                .WithMany(s => s.OwnedProjects) // Багато проєктів
                .HasForeignKey(p => p.OwnerId) // Зовнішній ключ у Project
                .OnDelete(DeleteBehavior.Restrict); // Уникаємо каскадного видалення

            // Учасники проєкту (багато-до-багатьох)
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Participants) // Учасники
                .WithMany(s => s.ParticipatedProjects) // Проєкти, у яких студент бере участь
                .UsingEntity(j => j.ToTable("ProjectParticipants")); // Проміжна таблиця
        }
    }
}
