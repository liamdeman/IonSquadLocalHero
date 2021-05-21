using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proj2Aalst_G3.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Data.Mappers
{
    public class GameProfileConfiguration : IEntityTypeConfiguration<GameProfile>
    {
        public void Configure(EntityTypeBuilder<GameProfile> builder)
        {
            //Table name
            builder.ToTable("GameProfile");
            //primary key
            builder.HasOne(gp => gp.Game)
                .WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }
}