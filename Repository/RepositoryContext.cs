using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasOne(p => p.Owner)
                      .WithMany()
                      .HasForeignKey(p => p.OwnerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Mark)
                      .WithMany()
                      .HasForeignKey(p => p.MarkId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.HasOne(s => s.User)
                      .WithOne()
                      .HasForeignKey<Student>(s => s.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.Group)
                      .WithMany(g => g.Students)
                      .HasForeignKey(s => s.GroupId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(s => s.OwnedProjects)
                      .WithOne(p => p.Owner)
                      .HasForeignKey(p => p.OwnerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.HasOne(t => t.User)
                      .WithOne()
                      .HasForeignKey<Teacher>(t => t.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(t => t.Courses)
                      .WithOne(c => c.Teacher)
                      .HasForeignKey(c => c.TeacherId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            
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
        public DbSet<Project>? Projects { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<ProgrammingLanguage>? ProgrammingLanguages { get; set; }
        public DbSet<Technology>? Technologies { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Feedback>? Feedbacks { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Mark>? Marks { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }
    }
}
