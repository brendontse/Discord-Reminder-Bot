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
    // ModuleBase provides a base class for a command module to inherit from.
    // SocketCommandContext represents a WebSocket-based context of a command. This may include the client, guild, channel, user, and message.
    public class CoreCommands : ModuleBase<SocketCommandContext>
    {
        private CommandService _service;

        public CoreCommands(CommandService service)
        {
            _service = service;
        }


        [Command("hello"), Alias("hi"), Summary("Says Hello")]
        public async Task Hello()
        {
            await Context.Channel.SendMessageAsync($"Hello {Context.User.Username}");
            Console.WriteLine("Hello Message Recieved!");
        }
    }
}