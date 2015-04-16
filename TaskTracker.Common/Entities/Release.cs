using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Common.Entities
{
    public class Release : Entity<int>
    {
        public string Number { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
