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

        [Command("bitcoin", RunMode = RunMode.Async)]
        [Alias("bitcoin price", "bitcoin status", "bitcoin updates", "bitcoin update", "bitcoin")]
        [Summary("returns the current price of bitcoin vs usd")]
        public async Task GetAdviceAsync()
        {
            string errorMessage = "Unable to fetch current price of bitcoin. Try later!";
            string output;
            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("https://api.coingecko.com/") };
                var response = await client.GetAsync("api/v3/simple/price?ids=bitcoin&vs_currencies=usd&include_market_cap=false&include_24hr_vol=false&include_24hr_change=true&include_last_updated_at=false");

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var btcData = (JsonConvert.DeserializeObject<CryptoData>(data));
                    var number = (int)btcData.Bitcoin.Usd24hChange;

                    output = number switch
                    {
                        0 => $"Just flat and constant! Bitcoin is  {btcData.Bitcoin.Usd:n0} per USD with almost {btcData.Bitcoin.Usd24hChange:n0} percent change reported in last 24 hours.",
                        1 => $"Nothing much interesting in crypto market today! Currently bitcoin is {btcData.Bitcoin.Usd:n0} per USD, with just {btcData.Bitcoin.Usd24hChange:n0} percent change reported in last 24 hours.",
                        _ => $"Breaking News! There is a {btcData.Bitcoin.Usd24hChange:n0} percent change in price of bitcoin, currently standing at {btcData.Bitcoin.Usd:n0} per USD, "
                    };
                }
                else
                {
                    output = errorMessage;
                }
            }
            catch (Exception)
            {
                output = errorMessage;
            }
            await ReplyAsync(output);
        }

        [Command("commandName", RunMode = RunMode.Async)]
        [Alias("alias1", "alias2", "etc")]
        [Summary("Description of the command")]
        public Task CommandAsync()
        {
            return ReplyAsync("Your Return Text!");
        }
    }
}