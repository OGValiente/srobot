using Discord;
using Discord.Commands;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using HtmlAgilityPack; 

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

		[Command("unique")]
		public async Task UniqueRank()
		{
			using (var webClient = new WebClient())
			{
				//LOAD HTML DATA
				string webData = webClient.DownloadString("https://silkroad.gamegami.com/ranking_unique.php?id=1");
				HtmlDocument doc = new HtmlDocument();
				doc.LoadHtml(webData);
				//GET RELATED CONTENT
				string ranking = doc.GetElementbyId("ticketlist_content").InnerHtml;
				//PREVENT DATA OVERFLOW
				string rankingFirst2000 = ranking.Substring(0,1316);
				//SPLIT DATA BY COMMAS
				string[] rankingData = rankingFirst2000.Split(",", 112);
				//ARRAY TO STRING
				string splitRanking = string.Empty;
				foreach (var str in rankingData) 
				{
					splitRanking += str;
				}
				//SPLIT DATA BY VALUE
				string[] splitRankingArray = splitRanking.Split("jsondat", 2);
				//SPLIT BY CHARACTER NAMES
				string[] finalRanking = splitRankingArray[1].Split(@"Ch"":""");
				//SPLIT NAMES FROM THE REST OF THE STRING
				string[] rankingTop4 = new string[4];
				for (int i=0; i< finalRanking.Length; i++) 
				{
					if (i == 0) 
					{
						continue;
					}
					rankingTop4[i - 1] = finalRanking[i].Split(@"""")[0];
				}
				//FORMAT
				splitRanking = string.Empty;
				int rank = 1;
				foreach (var str in rankingTop4) 
				{
					splitRanking += $"{rank}- ";
					splitRanking += str;
					splitRanking += Environment.NewLine;
					rank++;
				}

				var EmbedBuilder = new EmbedBuilder()
				.WithFooter(footer =>
				{
					footer
					.WithText(splitRanking);
				});
				Embed embed = EmbedBuilder.Build();
				await ReplyAsync(embed: embed);
			}
		}
	}

	public static class DovizData
	{
		public static DovizJson DovizJson { get; set; }
	}
}