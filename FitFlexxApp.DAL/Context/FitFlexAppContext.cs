using FitFlexApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitFlexApp.DAL.Context
{
    public class FitFlexAppContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserSubscriptionPlan> UserSubscriptionPlans { get; set; } = null!;
        public DbSet<Plan> Plans { get; set; } = null!;

        public FitFlexAppContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
