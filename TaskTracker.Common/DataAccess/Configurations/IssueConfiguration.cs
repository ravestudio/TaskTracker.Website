using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;
using TaskTracker.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.Common.DataAccess.Configurations
{
    public class IssueConfiguration : EntityTypeConfiguration<Issue>
    {
        public IssueConfiguration()
        {
            Map(m =>
            {
                HasKey(p => p.Id);

                Property(p => p.Id).HasColumnName("Id").IsRequired();
                Property(p => p.Key).HasColumnName("Key");

                Property(p => p.IssueNumber).HasColumnName("IssueNumber").IsRequired();
                Property(p => p.Title).HasColumnName("Title").IsRequired();

                Property(p => p.Description).HasColumnName("Description").IsOptional();


                HasRequired(p => p.Status).WithMany().Map(mp => mp.MapKey("StatusId"));

                HasOptional(p => p.Release).WithMany().Map(mp => mp.MapKey("ReleaseId"));

            }).ToTable("IssueSet");

        }
    }
}
