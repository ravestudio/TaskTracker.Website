using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Common.DataAccess
{
    public class TTInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TTDataContext>
    {
        protected override void Seed(TTDataContext context)
        {
            var statusActive = new Entities.IssueStatus() { Name = "Active" };
            var statusInProgress = new Entities.IssueStatus() { Name = "InProgress" };
            var statusTesting = new Entities.IssueStatus() { Name = "Testing" };
            var statusDone = new Entities.IssueStatus() { Name = "Done" };

            context.Statuses.Add(statusActive);
            context.Statuses.Add(statusInProgress);
            context.Statuses.Add(statusTesting);
            context.Statuses.Add(statusDone);
        }
    }
}
