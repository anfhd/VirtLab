using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
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

            entity.HasMany(s => s.Projects)
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