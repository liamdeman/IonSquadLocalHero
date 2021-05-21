using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proj2Aalst_G3.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Data.Mappers
{
    public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            //Table name
            builder.ToTable("Tournament");
            //primary key
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Platforms).HasConversion(
                v => string.Join(',', v),
                v => new List<string>(v.Split(',', StringSplitOptions.RemoveEmptyEntries)));
        }
    }
}