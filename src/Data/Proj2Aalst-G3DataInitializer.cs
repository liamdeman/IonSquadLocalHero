using System;
using System.Collections.Generic;
using System.Linq;
using Proj2Aalst_G3.Models.Domain;
using Proj2Aalst_G3.Services.Toornament;
﻿using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Proj2Aalst_G3.Data
{
    public class Proj2Aalst_G3DataInitializer
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly IToornamentService toornamentService;

        public Proj2Aalst_G3DataInitializer(
            ApplicationDbContext dbContext,
            IToornamentService toornamentService,
            UserManager<ApplicationUser> userManager)
        {
            this.toornamentService = toornamentService;
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public void InitializeData()
        {
            dbContext.Database.EnsureDeleted();
            InitializeDataProd();
        }

        public void InitializeDataProd()
        {
            //dbContext.Database.Migrate();
            if (dbContext.Database.EnsureCreated())
            {
                if (!dbContext.Blogposts.Any())
                {
                    var eersteBlogPost = new Blogpost(
                        "Eerste blogpost", "Eerste blogpost op de website.");
                    dbContext.Blogposts.AddRange(eersteBlogPost);
                }
                if (!dbContext.Games.Any())
                {
                    var leagueOfLegends =
                        new Game(
                            "League of Legends",
                            LoginService.Riot);
                    var rocketLeague =
                        new Game("Rocket League",
                            LoginService.Steam);
                    var fortnite =
                        new Game("Fortnite",
                            LoginService.EpicGames);
                    fortnite.DiscordIconId = 818934961046159381;
                    dbContext.Games.AddRange(leagueOfLegends, rocketLeague, fortnite);
                }

                if (!dbContext.Platforms.Any())
                {
                    var platforms = new List<Platform>()
                    {
                        new("pc", "PC"),
                        new("playstation4", "Playstation 4"),
                        new("xbox_one", "Xbox One"),
                        new("nintendo_switch", "Nintendo Switch"),
                        new("mobile", "Mobiel"),
                        new("playstation3", "Playstation §"),
                        new("playstation2", "Playstation 2"),
                        new("playstation1", "Playstation 1"),
                        new("ps_vita", "Playstation Vita"),
                        new("psp", "PSP"),
                        new("xbox360", "Xbox 360"),
                        new("xbox", "Xbox"),
                        new("wii_u", "Wii U"),
                        new("wii", "Wii"),
                        new("gamecube", "GameCube"),
                        new("nintendo64", "Nintendo 64"),
                        new("snes", "SNES"),
                        new("nes", "NES"),
                        new("dreamcast", "SEGA Dreamcast"),
                        new("saturn", "SEGA Saturn"),
                        new("megadrive", "SEGA Genesis / Mega Drive"),
                        new("master_system", "SEGA Master System"),
                        new("3ds", "Nintendo 3DS"),
                        new("ds", "Nintendo DS"),
                        new("game_boy", "Game Boy"),
                        new("neo_geo", "Neo Geo"),
                        new("other_platform", "Ander platform"),
                        new("not_video_game", "Geen videogame")
                    };

                    dbContext.Platforms.AddRange(platforms);
                }

                var registrations = toornamentService.GetRegistrations(filter: null).Result;
                dbContext.Registrations.AddRange(registrations);
                
                InitializeUsers().Wait();
                
                dbContext.SaveChanges();
            }
        }

        private async Task InitializeUsers()
        {
            ApplicationUser user = new ApplicationUser("admin", "admin@admin.com");
            user.EmailConfirmed = true;
            await userManager.CreateAsync(user, "P@ssword1");
            await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "admin"));
            
            // Seed statistics
            var rnd = new Random();
            int range = 356;
            
            for (int i = 1; i <= 50; i++)
            {
                var creationDate = DateTime.Today.AddDays(-rnd.Next(range));
                ApplicationUser seedUser = new($"account{i}", $"account{i}@testusers.local")
                {
                    CreationDate = creationDate,
                    GameProfiles = await GetRandomGameProfiles(rnd, $"gameAccount{i}")
                };
                user.EmailConfirmed = true;
                await userManager.CreateAsync(seedUser, "P@ssword1");
                await userManager.AddClaimAsync(seedUser, new Claim(ClaimTypes.Role, "user"));
            }
            
            for (int i = 1; i <= 200; i++)
            {
                var creationDate = DateTime.Today.AddDays(-rnd.Next(range));
                ApplicationUser seedUser = new($"discordaccount{i}", $"discordaccount{i}@testusers.local")
                {
                    CreationDate = creationDate,
                    DiscordUserName = $"DiscordUser{i}",
                    DiscordDiscriminator = $"{rnd.Next(1000, 10000)}",
                    GameProfiles = await GetRandomGameProfiles(rnd, $"gameAccount{i}")
                };
                user.EmailConfirmed = true;
                await userManager.CreateAsync(seedUser, "P@ssword1");
                await userManager.AddClaimAsync(seedUser, new Claim(ClaimTypes.Role, "user"));
            }
        }

        private async Task<List<GameProfile>> GetRandomGameProfiles(Random rnd, string profileAccName)
        {
            var returnList = new List<GameProfile>();
            var games = await dbContext.Games
                .ToListAsync();
            int amountOfGames = games.Count;
            var alreadyTaken = new List<Game>();
            for (int i = 0; i < rnd.Next(amountOfGames + 1); i++)
            {
                var game = games[rnd.Next(amountOfGames)];
                if (alreadyTaken.Contains(game))
                    continue;
                alreadyTaken.Add(game);
                returnList.Add(new GameProfile(profileAccName + game.ToornamentAlias, game));
            }

            return returnList;
        }
    }
}