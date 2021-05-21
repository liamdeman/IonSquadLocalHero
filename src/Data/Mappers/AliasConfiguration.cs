using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Data.Mappers
{
    public class AliasConfiguration : IEntityTypeConfiguration<Alias>
    {
        public void Configure(EntityTypeBuilder<Alias> builder)
        {
            builder.ToTable("Aliases");
            builder.HasKey(a => a.Value);
        }
    }
}