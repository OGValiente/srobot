using Discord;
using Discord.Commands;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace SROBOT.Modules
{
	public class Commands : ModuleBase<SocketCommandContext>
	{
		AltinJson altinJson;

		[Command("sa")]
		public async Task Selam()
		{
			await ReplyAsync("As");
		}

		[Command("ömer")]
		public async Task Omer()
		{
			await ReplyAsync("Piçömer81");
		}

		[Command("altın")]
		public async Task GramAltin()
		{
			using (var webClient = new WebClient())
			{
				var json = webClient.DownloadString("https://finans.truncgil.com/today.json");
				altinJson = JsonConvert.DeserializeObject<AltinJson>(json);
			}

			var EmbedBuilder = new EmbedBuilder()
				.WithFooter(footer =>
				{
					footer
					.WithText($"Gram altın kuru: " + altinJson.GramAltin)
					.WithIconUrl("https://www.boyakazan.com/image/cache/catalog/%C3%87E%C4%9EREK%20ALTIN-550x550h.png");
				});
			Embed embed = EmbedBuilder.Build();
			await ReplyAsync(embed: embed);
		}
	}
}
