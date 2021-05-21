using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSharpPlus.Entities;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Services.Matchmaking
{
    public class LfgUser
    {
        public string Username { get; }
        
        public string Discriminator { get; }
        public string AvatarUrl { get; }
        public ulong DiscordId { get; }
        public DateTime JoinedOn { get; }
        public ICollection<Game> Games { get; }

        public LfgUser(string username, string discriminator, string avatarUrl, ulong discordId, ICollection<Game> games)
        {
            Username = username;
            Discriminator = discriminator;
            AvatarUrl = avatarUrl;
            DiscordId = discordId;
            Games = games;
            JoinedOn = DateTime.Now;
        }

        public bool IsLookingFor(Game game)
        {
            return Games.Contains(game);
        }
        
        public void AddGame(Game game)
        {
            Games.Add(game);
        }

        public void AddGame(IEnumerable<Game> games)
        {
            foreach (var game in games)
                AddGame(game);
        }

        public bool TryAddGame(Game game)
        {
            if (IsLookingFor(game))
                return false;
            AddGame(game);
            return true;
        }

        public void RemoveGame(Game game)
        {
            Games.Remove(game);
        }

        public void RemoveGame(IEnumerable<Game> games)
        {
            foreach (var game in games)
                RemoveGame(game);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as LfgUser);
        }

        public bool Equals(LfgUser other)
        {
            return other != null &&
                   Username.Equals(other.Username) &&
                   Discriminator.Equals(other.Discriminator) &&
                   DiscordId.Equals(other.DiscordId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Discriminator, DiscordId);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var game in Games)
                builder.Append($"{game} ");
            return $"{Username}#{Discriminator}{{{builder}}}\n";
        }
    }
}
