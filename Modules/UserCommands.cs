using CouchBot.UserCommands.Models;
using Discord.Commands;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CouchBot.UserCommands.Modules
{
    public class UserCommands : ModuleBase
    {
        // 1. Copy the following code.
        // 2. Paste it below this code.
        // 3. Give your command a one word name.
        // 4. Include any aliases you think fit your command.
        // 5. Provide a summary of what the command does.
        // 6. Implement your command
        //[Command("commandName", RunMode = RunMode.Async)]
        //[Alias("alias1", "alias2", "etc")]
        //[Summary("Description of the command")]
        //public Task CommandAsync()
        //{
        //    return ReplyAsync("Your Return Text!");
        //}


        [Command("covid", RunMode = RunMode.Async)]
        [Alias("covid status", "covid stats", "covid news", "covid today", "covid updates", "corona", "coronavirus")]
        [Summary("returns the latest covid cases cases updates using public API")]
        public Task GetCovidDataAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://corona.lmao.ninja/");
                    var response = client.GetAsync("v2/all").GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        CovidData covidData = JsonConvert.DeserializeObject<CovidData>(data);

                        Random random = new Random();
                        var number = random.Next(1, 4);

                        switch (number)
                        {
                            case 1:
                                return ReplyAsync(string.Format("Out of {0} total cases, {1} were reported today.",
                                covidData.Cases, covidData.TodayCases));
                            case 2:
                                return ReplyAsync(string.Format("Out of {0} deaths, {1} were died today.",
                                covidData.Deaths, covidData.TodayDeaths));
                            default:
                                return ReplyAsync(string.Format("Great news! {0} people recovered today.",
                                covidData.TodayRecovered));
                        }
                    }
                    else
                    {
                        return ReplyAsync("I'm feeling dizzy");
                    }
                }
            }
            catch (Exception ex)
            {
                return ReplyAsync("I'm exhausted");
            }

        }
    }
}