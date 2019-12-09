using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

//Variables------------------------------------------------------------------------------------------------


//Functions------------------------------------------------------------------------------------------------
namespace EventBot
{
	public class EventBot
	{

		private DiscordSocketClient _client;

		public static void Main(string[] args)
			=> new EventBot().MainAsync().GetAwaiter().GetResult();

		public async Task MainAsync()
		{
			_client = new DiscordSocketClient();

			_client.Log += Log;

			string token = "TOKEN_GOES_HERE";
			// string token = Environment.GetEnvironmentVariable(".env");
		
			await _client.LoginAsync(TokenType.Bot, token);
			await _client.StartAsync();


			await Task.Delay(-1);
		}

		private Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
		}
	}

}