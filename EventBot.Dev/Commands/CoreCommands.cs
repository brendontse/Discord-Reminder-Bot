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
            // create a new list of Embed objects to be sent to user
            // DEV NOTE: Discord has a character limit of 6000. Write a try-catch block to handle the exception when necessary.
            List<EmbedBuilder> helpEmbeds = new List<EmbedBuilder>();

            string fieldValue = ""; //where do i put this lmfao

            // create an Embed object for every command
            foreach (var module in _service.Modules) 
            {
                // creates an EmbedBuilder object w/ fields that may be useful to user (command name, syntax, description, etc)
                EmbedBuilder builder = new EmbedBuilder();
                // //WithAuthor(String, String, String) || Sets the author field of an Embed with the provided name, icon URL, and URL.
                // builder.WithAuthor(Context.Client.CurrentUser.Username);
                
                // //AddField(String, Object, Boolean) || Adds an Embed field with the provided name and value.
                // // DEV NOTE: Discord has a field count limit of 25. Write a try-catch block to handle the exception when necessary.
                // builder.AddField(module.Name, fieldValue);

                // builder.WithThumbnailUrl("");

                // add current Embed object to the helpEmbeds list
                helpEmbeds.Add(builder);

                // builder = new EmbedBuilder();
            }

            foreach (var embed in helpEmbeds) {
                await Context.User.SendMessageAsync("", false, embed.Build());
            }

            await Context.Channel.SendMessageAsync($"Fear not {Context.Message.Author.Mention}, help is on the way! Check your DM's!");
        }
    }
}
