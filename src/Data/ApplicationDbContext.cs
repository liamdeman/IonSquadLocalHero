using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Proj2Aalst_G3.Models.Domain;
using Proj2Aalst_G3.Data.Mappers;

namespace Proj2Aalst_G3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<StatisticsData> StatisticsData { get; set; }
        public DbSet<StatisticsData.PageHitCounter> PageHitCounters { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Blogpost> Blogposts { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new GameProfileConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());
            modelBuilder.ApplyConfiguration(new AliasConfiguration());
            modelBuilder.ApplyConfiguration(new PlatformConfiguration());
            modelBuilder.ApplyConfiguration(new StatisticsDataConfiguration());
            modelBuilder.ApplyConfiguration(new PageHitCounterConfiguration());
            modelBuilder.ApplyConfiguration(new RegistrationConfiguration());
        }
    }
}