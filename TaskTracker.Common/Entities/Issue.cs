using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Common.Entities
{
    public class Issue : Entity<int>
    {
        public int IssueNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual IssueStatus Status { get; set; }

        public virtual Release Release { get; set; }
    }
}
