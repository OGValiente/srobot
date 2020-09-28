using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace SROBOT
{
	class Program
	{
		private DiscordSocketClient client;
		private CommandService commands;
		private IServiceProvider services;
		const string token = "NzYwMDg2NTU1Njc0MTQ4ODc2.X3G7xA.emBgwfSN_qs2tQJrK7J3ry3NPHQ";
		const string prefix = "!";

		static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

		public async Task RunBotAsync()
		{
			client = new DiscordSocketClient();
			commands = new CommandService();
			services = new ServiceCollection()
				.AddSingleton(client)
				.AddSingleton(commands)
				.BuildServiceProvider();

			client.Log += clientLog;

			await RegisterCommandsAsync();

			await client.LoginAsync(TokenType.Bot, token);

			await client.StartAsync();

			await Task.Delay(-1);
		}

		private Task clientLog(LogMessage arg)
		{
			Console.WriteLine(arg);
			return Task.CompletedTask;
		}

		public async Task RegisterCommandsAsync()
		{
			client.MessageReceived += HandleCommandAsync;
			await commands.AddModulesAsync(Assembly.GetEntryAssembly(), services);
		}

		private async Task HandleCommandAsync(SocketMessage arg)
		{
			var message = arg as SocketUserMessage;
			var context = new SocketCommandContext(client, message);

			if (message.Author.IsBot)
			{
				return;
			}

			int argPos = 0;
			if (message.HasStringPrefix(prefix, ref argPos))
			{
				var result = await commands.ExecuteAsync(context, argPos, services);
				if (!result.IsSuccess)
				{
					Console.WriteLine(result.ErrorReason);
				}
			}
		}
	}
}
