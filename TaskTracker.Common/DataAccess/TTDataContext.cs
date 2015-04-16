using System.Data.Entity;
using TaskTracker.Common.Entities;

namespace TaskTracker.Common.DataAccess
{
    public class TTDataContext : DbContext
    {
        public TTDataContext()
            : base("DefaultConnection")
        {
            //this.Database.Delete();

            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = true;

            this.Configuration.AutoDetectChangesEnabled = true;

            Database.SetInitializer(new TTInitializer());
        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueStatus> Statuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TaskTracker.Common.DataAccess.Configurations.IssueConfiguration());
            modelBuilder.Configurations.Add(new TaskTracker.Common.DataAccess.Configurations.IssueStatusConfiguration());
        }
    }
}
