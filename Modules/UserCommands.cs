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

        /// <summary>
        /// Originally created by Farshan Ahamed. Thanks!
        /// Prepared for import into CouchBot by Matt.
        /// </summary>
        /// <returns>Outputs message to Discord Channel.</returns>
        [Command("covid", RunMode = RunMode.Async)]
        [Alias("covid status", "covid stats", "covid news", "covid today", "covid updates", "corona", "coronavirus")]
        [Summary("returns the latest covid cases cases updates using public API")]
        public async Task GetCovidDataAsync()
        {
            string output;

            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("https://corona.lmao.ninja/") };

                var response = await client.GetAsync("v2/all");

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var covidData = JsonConvert.DeserializeObject<CovidData>(data);
                    var random = new Random();
                    var number = random.Next(1, 4);

                    output = number switch
                    {
                        1 => $"Out of {covidData.Cases:n0} total cases, {covidData.TodayCases:n0} were reported today.",
                        2 => $"Out of {covidData.Deaths:n0} deaths, {covidData.TodayDeaths:n0} died today.",
                        _ => $"Great news! {covidData.TodayRecovered:n0} people recovered today."
                    };
                }
                else
                {
                    output = "I'm feeling dizzy";
                }
            }
            catch (Exception)
            {
                output = "I'm exhausted";
            }

            await ReplyAsync(output);
        }

        [Command("Advice", RunMode = RunMode.Async)]
        [Alias("advice", "quote", "tip")]
        [Summary("returns a random life advice")]
        public async Task GetAdviceAsync()
        {
            string errorMessage = "An error occured while fetching advice";

            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("https://api.adviceslip.com/") };
                var response = await client.GetAsync("advice");

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var advice = JsonConvert.DeserializeObject<AdviceObject>(data);
                    await ReplyAsync(advice.AdviceSlip.AdviceText);
                }
                else
                {
                    await ReplyAsync(errorMessage);
                }
            }
            catch (Exception)
            {
                await ReplyAsync(errorMessage);
            }
        }
    }
}