using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSharpPlus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Proj2Aalst_G3.Data;
using Proj2Aalst_G3.Data.Repositories;
using Proj2Aalst_G3.Models.Domain;
using Proj2Aalst_G3.Services.DiscordBot;
using Proj2Aalst_G3.Services.Matchmaking;
using Xunit;

namespace Project.UnitTests.DiscordServiceTests
{
    public class MatchmakerShould
    {
        private MatchmakingService _matchmakingService;
        private ApplicationDbContext _dbContext;

        private Game _leagueOfLegends = new("League of Legends", LoginService.Riot);
        private Game _rocketLeague = new("Rocket League", LoginService.Steam);
        private Game _fortnite = new("Fortnite", LoginService.EpicGames);
        private LfgUser user1 = new LfgUser("user1", "1000", null, 0, new List<Game>());
        private LfgUser user2 = new LfgUser("user2", "2000", null, 1, new List<Game>());

        public MatchmakerShould()
        {
            // Set up InMemory Database for tests
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "IonSquadDb")
                .Options;
            _dbContext = new ApplicationDbContext(options);
            
            // Add Data
            using (_dbContext)
            {
                if (!_dbContext.Games.Contains(_leagueOfLegends))
                    _dbContext.Games.AddRange(_leagueOfLegends, _rocketLeague, _fortnite);
                _dbContext.SaveChanges();
                _matchmakingService = new MatchmakingService(_dbContext);
            }
        }

        [Fact]
        public void ContainAllGames()
        {
            Assert.Equal(3, MatchmakingService.Games.Count);
        }

        [Fact]
        public void AddsUsersToLfgCorrectly()
        {
            ICollection<Game> games1 = new List<Game> { _leagueOfLegends, _fortnite };
            ICollection<Game> games2 = new List<Game> { _leagueOfLegends, _rocketLeague };
            _matchmakingService
                .AddUser(
                    user1.Username, 
                    user1.Discriminator, 
                    user1.AvatarUrl, 
                    user1.DiscordId, 
                    games1
                );
            _matchmakingService
                .AddUser(
                    user1.Username,
                    user1.Discriminator,
                    user1.AvatarUrl,
                    user1.DiscordId,
                    _leagueOfLegends
                );
            _matchmakingService
                .AddUser(
                    user2.Username,
                    user2.Discriminator,
                    user2.AvatarUrl,
                    user2.DiscordId,
                    new List<Game> { _leagueOfLegends, _rocketLeague }
                );
            foreach (var game in _matchmakingService.GetUser(user1.Username, user1.Discriminator, user1.DiscordId).Games)
            {
                Assert.Contains(game, games1);
            }
            foreach (var game in _matchmakingService.GetUser(user2.Username, user2.Discriminator, user2.DiscordId).Games)
            {
                Assert.Contains(game, games2);
            }
        }
    }
}
