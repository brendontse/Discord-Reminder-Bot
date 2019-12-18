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
    [Name("Core Commands")]
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
            await Context.Channel.SendMessageAsync($"Hello {Context.Message.Author.Mention}");
            Console.WriteLine("Hello Message Recieved!");
        }

        [Command("help"), Alias("info"), Summary("Sends user a list of commands and info on commands")]
        private async Task GetHelp()
        {
            // Builder class is used to build an Embed (rich embed) object that will be ready to be sent via SendMessageAsync after Build is called
            List<EmbedBuilder> helpEmbeds = new List<EmbedBuilder>();
            EmbedBuilder builder = new EmbedBuilder();
            //Sets the author of an Embed.
            builder.WithAuthor(Context.Client.CurrentUser.Username);

            foreach (var cmd in mod.Commands) {
                var attrs = cmd.Attributes;
                bool isHidden = false;
                foreach (var attr in attrs) 
                {
                    if (attr is HiddenAttribute) 
                    {
                    isHidden = true;
                    break;
                    }
                }
            }

            await Context.Channel.SendMessageAsync("Help is on the way, check your DM's!");
        }
    }

}
