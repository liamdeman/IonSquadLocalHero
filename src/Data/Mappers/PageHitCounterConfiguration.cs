using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Data.Mappers
{
    public class PageHitCounterConfiguration : IEntityTypeConfiguration<StatisticsData.PageHitCounter>
    {
        public void Configure(EntityTypeBuilder<StatisticsData.PageHitCounter> builder)
        {
            builder.ToTable("PageHitData");
            builder.HasKey(p => new { p.Controller, p.Action });
            builder.Property(p => p.Hits)
                .IsRequired();
        }
    }
}
