using Discord.Commands;
using System.Threading.Tasks;

namespace SROBOT.Modules
{
	public class Commands : ModuleBase<SocketCommandContext>
	{
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
	}
}
