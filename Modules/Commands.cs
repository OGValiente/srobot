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
		[Command("gram")]
		public async Task GramAltin()
		{
			var EmbedBuilder = new EmbedBuilder()
				.WithFooter(footer =>
				{
					footer
					.WithText($"Gram altın kuru\nAlış: {DovizData.DovizJson.GramAltın.Alış}\nSatış: {DovizData.DovizJson.GramAltın.Satış}");
				});
			Embed embed = EmbedBuilder.Build();
			await ReplyAsync(embed: embed);
		}

		[Command("ons")]
		public async Task OnsAltin()
		{
			var EmbedBuilder = new EmbedBuilder()
				.WithFooter(footer =>
				{
					footer
					.WithText($"ONS\nAlış: {DovizData.DovizJson.OnsAltın.Alış}\nSatış: {DovizData.DovizJson.OnsAltın.Satış}");
				});
			Embed embed = EmbedBuilder.Build();
			await ReplyAsync(embed: embed);
		}

		[Command("dolar")]
		public async Task Dolar()
		{
			var EmbedBuilder = new EmbedBuilder()
				.WithFooter(footer =>
				{
					footer
					.WithText($"Dolar kuru\nAlış: {DovizData.DovizJson.AbdDolari.Alış}\nSatış: {DovizData.DovizJson.AbdDolari.Satış}");
				});
			Embed embed = EmbedBuilder.Build();
			await ReplyAsync(embed: embed);
		}

		[Command("euro")]
		public async Task Euro()
		{
			var EmbedBuilder = new EmbedBuilder()
				.WithFooter(footer =>
				{
					footer
					.WithText($"Euro kuru\nAlış: {DovizData.DovizJson.Euro.Alış}\nSatış: {DovizData.DovizJson.Euro.Satış}");
				});
			Embed embed = EmbedBuilder.Build();
			await ReplyAsync(embed: embed);
		}

		[Command("çeyrek")]
		public async Task CeyrekAltin()
		{
			var EmbedBuilder = new EmbedBuilder()
				.WithFooter(footer =>
				{
					footer
					.WithText($"Çeyrek altın kuru\nAlış: {DovizData.DovizJson.ÇeyrekAltın.Alış}\nSatış: {DovizData.DovizJson.ÇeyrekAltın.Satış}");
				});
			Embed embed = EmbedBuilder.Build();
			await ReplyAsync(embed: embed);
		}

		[Command("gümüş")]
		public async Task Gumus()
		{
			var EmbedBuilder = new EmbedBuilder()
				.WithFooter(footer =>
				{
					footer
					.WithText($"Gümüş kuru\nAlış: {DovizData.DovizJson.Gümüş.Alış}\nSatış: {DovizData.DovizJson.Gümüş.Satış}");
				});
			Embed embed = EmbedBuilder.Build();
			await ReplyAsync(embed: embed);
		}
	}

	public static class DovizData
	{
		public static DovizJson DovizJson { get; set; }
	}
}
