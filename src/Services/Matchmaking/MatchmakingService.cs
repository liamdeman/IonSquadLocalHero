using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using DSharpPlus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Proj2Aalst_G3.Data;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Services.Matchmaking
{
    public class MatchmakingService
    {
        private static HashSet<LfgUser> _users = new();
        public static ImmutableList<Game> Games { get; set; }
        //private LfgUserRepository UserRepository { get; } = new();

        public MatchmakingService(ApplicationDbContext dbContext)
        {
            Games ??= dbContext.Games
                .ToImmutableList();
            _users.Add(new LfgUser("gebruiker1", "1234", "", 25, Games.Where(g => g.Name != "League of Legends").ToList()));
            _users.Add(new LfgUser("gebruiker2", "5678", "", 26, Games.Where(g => g.Name != "Rocket League").ToList()));
            _users.Add(new LfgUser("gebruiker3", "9876", "", 27, Games.Where(g => g.Name == "Fortnite").ToList()));
            _users.Add(new LfgUser("gebruiker4", "5432", "", 28, Games));
        }

        public void AddUser(string username, string discriminator, string avatarUrl, ulong discordId, Game game)
        {
            var user = new LfgUser(username, discriminator, avatarUrl, discordId, new List<Game> {game});
            if (!_users.Add(user))
            {
                _users.TryGetValue(user, out user);
                user?.AddGame(game);
            }
        }

        public void AddUser(string username, string discriminator, string avatarUrl, ulong discordId, ICollection<Game> games)
        {
            var user = new LfgUser(username, discriminator, avatarUrl, discordId, games);
            if (!_users.Add(user))
            {
                _users.TryGetValue(user, out user);
                user?.AddGame(games);
            }
        }

        public LfgUser GetUser(string username, string discriminator, ulong discordId)
        {
            var user = new LfgUser(username, discriminator, null, discordId, null);
            var isSuccess = _users.TryGetValue(user, out user);
            return isSuccess ? user : null;
        }

        public IEnumerable<LfgUser> GetAllUsers()
        {
            return _users.ToImmutableList();
        }

        public void RemoveUser(string discordName, string discordDiscriminator)
        {
            _users.RemoveWhere(u => u.Username == discordName && u.Discriminator == discordDiscriminator);
        }
    }
}