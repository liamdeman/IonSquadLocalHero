using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Data.Mappers
{
    public class StatisticsDataConfiguration : IEntityTypeConfiguration<StatisticsData>
    {
        public void Configure(EntityTypeBuilder<StatisticsData> builder)
        {
            builder.ToTable("StatisticsData");
            builder.HasKey(d => d.Date);
            builder.HasMany(d => d.PageHits)
                .WithOne();
        }
    }
}
