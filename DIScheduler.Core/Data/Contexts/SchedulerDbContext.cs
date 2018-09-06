using DIScheduler.Core.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DIScheduler.Core.Data.Contexts
{
    public class SchedulerDbContext : DbContext
    {
        public SchedulerDbContext() : base("SchedulerDbContext")
        {
            Database.SetInitializer<SchedulerDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<NextRun> NextRuns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            EfMapNextRun(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void EfMapNextRun(DbModelBuilder modelBuilder)
        {
            var nextRun = modelBuilder.Entity<NextRun>();
            nextRun.ToTable("DINextRun");
            nextRun.Property(x => x.Id).HasColumnName("DINextRunID");
        }
    }
}
