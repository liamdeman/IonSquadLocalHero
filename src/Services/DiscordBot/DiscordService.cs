using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Proj2Aalst_G3.Data;
using Proj2Aalst_G3.Data.Repositories;
using Proj2Aalst_G3.Models.Domain;
using Proj2Aalst_G3.Services.DiscordBot.Modules;

namespace Proj2Aalst_G3.Services.DiscordBot
{
    public class DiscordService
    {
        private readonly DiscordClient _client;
        private CommandsNextExtension _commands;
        private readonly IServiceScopeFactory _scopeFactory;

        private readonly string _prefix;
        private readonly string _lfgChannel;
        private readonly string _blogpostChannel;
        private List<Blogpost> _cachedList = new List<Blogpost>();
        private DiscordMessage _lastMessage;

        public DiscordService(
            string botToken,
            string prefix,
            string lfgChannel,
            string blogpostChannel,
            IServiceCollection services,
            IServiceScopeFactory scopeFactory)
        {
            _prefix = prefix;
            _lfgChannel = lfgChannel;
            _blogpostChannel = blogpostChannel;
            _scopeFactory = scopeFactory;

            _client = new DiscordClient(new DiscordConfiguration
            {
                Token = botToken,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All
            });

            var commandConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new[] {_prefix},
                EnableDms = true,
                EnableMentionPrefix = true,
                Services = services.BuildServiceProvider()
            };

            _commands = _client.UseCommandsNext(commandConfig);
        }

        public void StartBot()
        {
            _client.UseInteractivity(new InteractivityConfiguration()
            {
                PollBehaviour = PollBehaviour.KeepEmojis,
                Timeout = TimeSpan.FromSeconds(30)
            });

            _commands.RegisterCommands<LfgModule>();
            

            var result = Task.Run(async () =>
            {
                await _client.ConnectAsync();

                var token = new CancellationTokenSource();


                var tournamentResult = Task.Run(async () =>
                {


                    while (!token.IsCancellationRequested)
                    {
                        var daysTillTournament = DateTime.Now.AddDays(2);
                        var tournaments = await _scopeFactory.CreateScope().ServiceProvider.GetService<ITournamentRepository>().GetAtDate(daysTillTournament);
                        if (tournaments.Count() > 0)
                        {
                            var messageContent = "";
                            foreach (var item in tournaments)
                            {
                                messageContent += "Nog " + (item.RegistrationClosingDatetime.Value - DateTime.Now).Days.ToString() + " dagen mogelijk om u in te schrijven voor: " + item.Name.ToString();
                                var channel = await _client.GetChannelAsync(839842685580869654);
                                var message = await _client.SendMessageAsync(channel, new DiscordMessageBuilder().WithContent(messageContent.ToString()));
                            }

                        }
                        await Task.Delay(86400000);

                    }
                }, token.Token);


                await Task.Delay(-1);

            });

            
        }

        

        private async Task RefreshBlogposts()
        {
            var channel = await _client.GetChannelAsync(788177439343640597);

            if (_lastMessage != null)
            {
               await channel.DeleteMessageAsync(_lastMessage);
            }

             var sb = new StringBuilder();
             foreach (var blogpost in _cachedList)
             {
                sb.Append(blogpost.Title + ": \n" + blogpost.Text + "\n\n");
             }

             var discordMessageBuilder = new DiscordMessageBuilder().WithContent(sb.ToString());
             _lastMessage = await _client.SendMessageAsync(channel, string.IsNullOrEmpty(discordMessageBuilder.Content) ? discordMessageBuilder.WithContent("Momenteel zijn er geen nieuwsberichten") : discordMessageBuilder);
               
                
            
        }
    }
}