using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Project>? Projects { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<ProgrammingLanguage>? ProgrammingLanguages { get; set; }
        public DbSet<Technology>? Technologies { get; set; }
    }
}
