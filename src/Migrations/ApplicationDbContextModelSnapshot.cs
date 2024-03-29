﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proj2Aalst_G3.Data;

namespace Proj2Aalst_G3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.1.21102.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Alias", b =>
                {
                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Value");

                    b.ToTable("Aliases");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscordDiscriminator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscordUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("TeamName");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Blogpost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("PublicationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blogposts");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Game", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("DiscordIconId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("GameProfileProfileName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LoginService")
                        .HasColumnType("int");

                    b.Property<string>("ToornamentAlias")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.HasIndex("GameProfileProfileName");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.GameProfile", b =>
                {
                    b.Property<string>("ProfileName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProfileName");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("GameProfile");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Lineup", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomUserIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationId");

                    b.ToTable("Lineup");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Logo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LogoLarge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoMedium")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoSmall")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Original")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logo");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Platform", b =>
                {
                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShortName");

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Registration", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomUserIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParticipantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TournamentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.StatisticsData", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Date");

                    b.ToTable("StatisticsData");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.StatisticsData+PageHitCounter", b =>
                {
                    b.Property<string>("Controller")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Hits")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StatisticsDataDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Controller", "Action");

                    b.HasIndex("StatisticsDataDate");

                    b.ToTable("PageHitData");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Team", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Tournament", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<bool>("CheckInEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("CheckInParticipantEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CheckInParticipantEndDatetime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CheckInParticipantStartDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discipline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LogoId")
                        .HasColumnType("int");

                    b.Property<bool>("MatchReportEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Online")
                        .HasColumnType("bit");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParticipantType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platforms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Public")
                        .HasColumnType("bit");

                    b.Property<string>("RegistrationAcceptanceMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RegistrationClosingDatetime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RegistrationEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("RegistrationNotificationEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RegistrationOpeningDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistrationRefusalMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationRequestMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RegistrationTermsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("RegistrationTermsUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rules")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ScheduledDateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ScheduledDateStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamMaxSize")
                        .HasColumnType("int");

                    b.Property<int>("TeamMinSize")
                        .HasColumnType("int");

                    b.Property<string>("Timezone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("LogoId");

                    b.ToTable("Tournament");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Proj2Aalst_G3.Models.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Proj2Aalst_G3.Models.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proj2Aalst_G3.Models.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Proj2Aalst_G3.Models.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.ApplicationUser", b =>
                {
                    b.HasOne("Proj2Aalst_G3.Models.Domain.Team", null)
                        .WithMany("Members")
                        .HasForeignKey("TeamName");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Game", b =>
                {
                    b.HasOne("Proj2Aalst_G3.Models.Domain.GameProfile", null)
                        .WithMany("Games")
                        .HasForeignKey("GameProfileProfileName");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.GameProfile", b =>
                {
                    b.HasOne("Proj2Aalst_G3.Models.Domain.ApplicationUser", null)
                        .WithMany("GameProfiles")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Lineup", b =>
                {
                    b.HasOne("Proj2Aalst_G3.Models.Domain.Registration", null)
                        .WithMany("Lineup")
                        .HasForeignKey("RegistrationId");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.StatisticsData+PageHitCounter", b =>
                {
                    b.HasOne("Proj2Aalst_G3.Models.Domain.StatisticsData", null)
                        .WithMany("PageHits")
                        .HasForeignKey("StatisticsDataDate");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Tournament", b =>
                {
                    b.HasOne("Proj2Aalst_G3.Models.Domain.ApplicationUser", null)
                        .WithMany("Tournaments")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Proj2Aalst_G3.Models.Domain.Logo", "Logo")
                        .WithMany()
                        .HasForeignKey("LogoId");

                    b.Navigation("Logo");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.ApplicationUser", b =>
                {
                    b.Navigation("GameProfiles");

                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.GameProfile", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Registration", b =>
                {
                    b.Navigation("Lineup");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.StatisticsData", b =>
                {
                    b.Navigation("PageHits");
                });

            modelBuilder.Entity("Proj2Aalst_G3.Models.Domain.Team", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
