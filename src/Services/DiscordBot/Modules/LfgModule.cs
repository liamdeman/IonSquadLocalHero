using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Logging;
using Proj2Aalst_G3.Services.Matchmaking;

namespace Proj2Aalst_G3.Services.DiscordBot.Modules
{
    [ModuleLifespan(ModuleLifespan.Transient)]
    public class LfgModule : BaseCommandModule
    {
        public MatchmakingService MatchmakingService { private get; set; }
        public ILogger<LfgModule> Logger { private get; set; }

        [Command("matchmaking")]
        [Description("Zoek naar andere personen om mee te spelen. Hiervoor moet de bot je een privébericht kunnen sturen.")]
        public async Task LfgCommand(CommandContext ctx)
        {
            var lfgEmbed = new DiscordEmbedBuilder
                {
                    Title = "Matchmaking",
                    Description = "",
                    Color = new DiscordColor(28, 128, 219)
                }
                .AddField("Klik hier om naar de website te gaan en andere spelers te zoeken!",
                    "Je kan ook hieronder reageren met de game(s) waarvoor je medespelers zoekt!")
                .WithThumbnail("https://cdn.pixabay.com/photo/2015/12/08/17/40/magnifying-glass-1083378_960_720.png")
                .WithFooter("Reacties worden na 30 seconden geregistreerd.");
            
            DiscordMessage message;
            if (ctx.Member is not null)
                message = await ctx.Member.SendMessageAsync(lfgEmbed.Build());
            else
            {
                await ctx.TriggerTypingAsync();
                message = await ctx.RespondAsync(lfgEmbed.Build());
            }
            
            await Task.Delay(100);
            var gamesWithEmoji = MatchmakingService.Games
                .Where(g => g.DiscordIconId != null)
                .ToImmutableList();
            foreach (var game in gamesWithEmoji)
            {
                await message.CreateReactionAsync(
                    DiscordEmoji.FromGuildEmote(ctx.Client, game.DiscordIconId.GetValueOrDefault())
                );
            }

            var interactivity = ctx.Client.GetInteractivity();
            var reactions = await interactivity
                .CollectReactionsAsync(message, TimeSpan.FromSeconds(30));

            foreach (var reaction in reactions)
            {
                foreach (var game in gamesWithEmoji)
                {
                    var emoji = DiscordEmoji.FromGuildEmote(ctx.Client, game.DiscordIconId.GetValueOrDefault());
                    if (reaction.Emoji == emoji)
                    {
                        var user = ctx.User;
                        MatchmakingService.AddUser(user.Username, user.Discriminator, user.AvatarUrl, user.Id, game);
                        Logger.LogInformation("Added {game} to {member}'s matchmaking list.", game, user);
                    }
                }
            }
        }
    }
}