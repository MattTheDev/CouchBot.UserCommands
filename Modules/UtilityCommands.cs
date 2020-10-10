using System.Threading.Tasks;
using Discord.Commands;

namespace CouchBot.UserCommands.Modules
{
    public class UtilityCommands : ModuleBase
    {
        [Command("ping", RunMode = RunMode.Async)]
        [Summary("Basic ping command that returns a basic message on execution.")]
        public Task PingAsync()
        {
            return ReplyAsync("Pong!");
        }
    }
}