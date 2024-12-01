using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;
using File = Entities.Models.File;

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

                // Власник проєкту
                entity.HasOne(p => p.Owner)
                      .WithMany(s => s.OwnedProjects)
                      .HasForeignKey(p => p.OwnerId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Учасники проєкту
                entity.HasMany(p => p.Participants)
                      .WithMany(s => s.ParticipatedProjects)
                      .UsingEntity(j => j.ToTable("ProjectParticipants"));

                // Технології
                entity.HasMany(p => p.Technologies)
                      .WithMany(t => t.Projects)
                      .UsingEntity(j => j.ToTable("ProjectTechnologies"));

                // Мови програмування
                entity.HasMany(p => p.ProgrammingLanguages)
                      .WithMany(pl => pl.Projects)
                      .UsingEntity(j => j.ToTable("ProjectProgrammingLanguages"));
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

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasKey(m => m.Id);

                // Зв'язок Mark <-> Project
                entity.HasOne(m => m.Project)
                      .WithOne(p => p.Mark)
                      .HasForeignKey<Mark>(m => m.ProjectId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.HasOne(f => f.Project)
                      .WithMany(p => p.Files)
                      .HasForeignKey(f => f.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade); // Якщо видаляється проєкт, видаляються всі файли

                entity.HasMany(f => f.Versions)
                      .WithOne(v => v.File)
                      .HasForeignKey(v => v.FileId)
                      .OnDelete(DeleteBehavior.Cascade); // Якщо видаляється файл, видаляються всі його версії
            });

            modelBuilder.Entity<FileVersion>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Content); // Наприклад, щоб Content не міг бути null
                entity.Property(v => v.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            });
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
        public DbSet<UserPermission> Permissions { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FileVersion> FileVersions { get; set; }
    }
}
