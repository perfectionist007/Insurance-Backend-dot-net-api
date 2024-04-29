using backendapi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace backendapi.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Policy>()
                .HasOne(policy => policy.Category)
                .WithMany(category => category.Policies)
                .HasForeignKey(policy => policy.CategoryId);

            modelBuilder.Entity<Applicant>()
                .HasOne(applicant => applicant.Policy)
                .WithMany(policy => policy.Applicants)
                .HasForeignKey(applicant => applicant.PolicyId);

            modelBuilder.Entity<Category>()
                .Property(category => category.Level)
                .HasConversion<string>();

            modelBuilder.Entity<Policy>()
               .Property(policy => policy.Time)
               .HasConversion<string>();
        }
    }
}
