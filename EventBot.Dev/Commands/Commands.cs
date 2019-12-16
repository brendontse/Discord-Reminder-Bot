using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Addons.Interactive;

using Microsoft.Extensions.DependencyInjection;

namespace EventBotCommands
{
    class BotCommands
    {
        private CommandService _commands;
        private IServiceProvider _service;

        public BotCommands(DiscordSocketClient client)
        {
            // CommandService initializes a new CommandService class with the provided configuration (CommandServiceConfig).
            _commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = false,
                DefaultRunMode = RunMode.Async
            });

            _service = new ServiceCollection()
            .AddSingleton(client)
            .AddSingleton<InteractiveService>()
            .BuildServiceProvider();
        }

        public async Task SetupCommands()
        {
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _service);
        }
        
        public async Task ExecuteCommand(SocketCommandContext context, int argPosition)
        {
            var result = await _commands.ExecuteAsync(context, argPosition, _service);
            
            if (!result.IsSuccess) {
                if (result.Error.Value == CommandError.UnmetPrecondition) 
                {
                    await context.Channel.SendMessageAsync("You can't do that");
                } else if (result.Error.Value == CommandError.BadArgCount || result.Error.Value == CommandError.ParseFailed || result.Error.Value == CommandError.ObjectNotFound) {
                    await context.Channel.SendMessageAsync("Something went wrong");
                }
            }
        } 
    }
}