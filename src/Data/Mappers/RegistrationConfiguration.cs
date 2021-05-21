using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Data.Mappers
{
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable("Registrations");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .ValueGeneratedNever();
        }
    }

    public class LineupConfiguration : IEntityTypeConfiguration<Lineup>
    {
        public void Configure(EntityTypeBuilder<Lineup> builder)
        {
            builder.ToTable("Lineups");
            builder.HasKey(r => r.Id);
        }
    }
}
