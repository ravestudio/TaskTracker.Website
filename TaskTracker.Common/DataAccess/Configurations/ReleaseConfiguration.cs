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
    public class ReleaseConfiguration : EntityTypeConfiguration<Release>
    {
        public ReleaseConfiguration()
        {
            Map(m =>
            {
                HasKey(p => p.Id);

                Property(p => p.Id).HasColumnName("Id").IsRequired();
                Property(p => p.Key).HasColumnName("Key");

                Property(p => p.Number).HasColumnName("Number").IsRequired();

            }).ToTable("ReleaseSet");
        }
    }
}
