using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace SROBOT.Modules
{
	public class Commands : ModuleBase<SocketCommandContext>
	{
		[Command("sa")]
		public async Task Selam()
		{
			await ReplyAsync("As");
		}
	}
}
