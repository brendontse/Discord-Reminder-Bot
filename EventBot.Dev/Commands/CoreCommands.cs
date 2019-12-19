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

        [Command("welcome"), Summary("Gives a short welcome message")]
        public async Task Welcome()
        {
            await Context.Channel.SendMessageAsync($"Hi {Context.Message.Author.Mention}, I'm Reminder Bot! I'm a bot that will never forget your upcoming events once you tell me when they will happen.");
            await Context.Channel.SendMessageAsync("I hope to be able to remind you about upcoming events in your own Discord server someday!");
            await Context.Channel.SendMessageAsync("However, I'm still being built so I can't help you quite yet...");
            await Context.Channel.SendMessageAsync("In the meantime, feel free to offer suggestions or ideas to my developer if you have any!");
            await Context.Channel.SendMessageAsync("Bye for now!");
        }

        [Command("ping"), Summary("Plays ping-pong")]
        public async Task PingPong()
        {
            await Context.Channel.SendMessageAsync("pong");
        }

        [Command("hello"), Alias("hi"), Summary("Says Hello")]
        public async Task Hello()
        {
            await Context.Channel.SendMessageAsync($"Hello {Context.Message.Author.Mention}");
        }

        [Command("bye"), Alias("goodbye", "farewell", "goodnight"), Summary("Says Goodbye")]
        public async Task Goodbye()
        {
            await Context.Channel.SendMessageAsync($"See ya later {Context.Message.Author.Mention}! Come back soon!");
        }

        [Command("help"), Alias("info"), Summary("Sends user a list of commands and info on commands")]
        private async Task GetHelp()
        {
            // create a new list of Embed objects to be sent to user
            // DEV NOTE: Discord has a character limit of 6000. Write a try-catch block to handle the exception when necessary.
            List<EmbedBuilder> helpEmbeds = new List<EmbedBuilder>();

            // create an Embed object for every command
            foreach (var module in _service.Modules) 
            {
                // creates an EmbedBuilder object w/ fields that may be useful to user (command name, syntax, description, etc)
                EmbedBuilder builder = new EmbedBuilder();

                foreach (var command in module.Commands) {
                    
                }
                // //WithAuthor(String, String, String) || Sets the author field of an Embed with the provided name, icon URL, and URL.
                // builder.WithAuthor(Context.Client.CurrentUser.Username);
                
                // //AddField(String, Object, Boolean) || Adds an Embed field with the provided name and value.
                // // DEV NOTE: Discord has a field count limit of 25. Write a try-catch block to handle the exception when necessary.
                // builder.AddField(module.Name, fieldValue);

                // add current Embed object to the helpEmbeds list
                helpEmbeds.Add(builder);

            }

            foreach (var embed in helpEmbeds) {
                await Context.User.SendMessageAsync("Help has arrived...ok maybe not quite. This section is still a WIP!", false, embed.Build());
            }

            await Context.Channel.SendMessageAsync($"Fear not {Context.Message.Author.Mention}, help is on the way! Check your DM's!");
        }
    }
}
