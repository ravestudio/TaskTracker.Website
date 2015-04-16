using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Website.Models
{
    public class IssueViewModel
    {
        public int Id { get; set; }
        public int IssueNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ReleaseId { get; set; }
        public int StatusId { get; set; }
    }
}