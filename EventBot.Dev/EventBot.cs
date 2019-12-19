using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

using EventBotCommands;


namespace EventBot
{
	public class EventBot
	{

		//Variables------------------------------------------------------------------------------------------------

		//token no longer stored in system environment variables
		public static string token = Environment.botToken;

		static int argPos = 0;

		private BotCommands _botCommands;


		//Functions------------------------------------------------------------------------------------------------
		private DiscordSocketClient _client;

		// makes code asynchronous
		public static void Main(string[] args)
			=> new EventBot().MainAsync().GetAwaiter().GetResult();

		public async Task MainAsync()
		{
			_client = new DiscordSocketClient();
			_client.Log += Log;
			
			_botCommands = new BotCommands(_client);
				if (_botCommands != null) {
				await _botCommands.SetupCommands();
				}

			_client.MessageReceived += MessageReceived;

			await _client.LoginAsync(TokenType.Bot, token);
			await StartConnection();
		}

		//starts connection and keeps it running until manually stopped
		private async Task StartConnection()
		{
			await _client.StartAsync();
			await Task.Delay(-1);
		}
		
		private async Task MessageReceived(SocketMessage messageParameter)
		{
			var message = messageParameter as SocketUserMessage;
			var context = new SocketCommandContext(_client, message);
			
			var user = context.User as SocketGuildUser;
			
			//tells bot to ignore its own messages
			if (context.User.IsBot) return;

			if (!(message.HasStringPrefix(Environment.prefix, ref argPos))) return;

			await _botCommands.ExecuteCommand(context, argPos);
		}

		private Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
		}
	}

}