using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using SROBOT.Modules;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SROBOT
{
	class Program
	{
		private DiscordSocketClient client;
		private CommandService commands;
		private IServiceProvider services;
		private ConfigJson configJson;

		static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

		public async Task RunBotAsync()
		{
			var json = string.Empty;
			using (var fs = File.OpenRead("config.json"))
			using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
				json = await sr.ReadToEndAsync().ConfigureAwait(false);

			configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

			using (var webClient = new WebClient())
			{
				var todayJson = webClient.DownloadString("https://finans.truncgil.com/today.json");
				var convertedJson = JsonConvert.DeserializeObject<DovizJson>(todayJson);
				DovizData.DovizJson = convertedJson;
			}

			client = new DiscordSocketClient();
			commands = new CommandService();
			services = new ServiceCollection()
				.AddSingleton(client)
				.AddSingleton(commands)
				.BuildServiceProvider();

			client.Log += clientLog;

			await RegisterCommandsAsync();

			await client.LoginAsync(TokenType.Bot, configJson.Token);

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
			if (message.HasStringPrefix(configJson.Prefix, ref argPos))
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
