using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CouchBot.UserCommands.Models
{
    public class CryptoData
    {
        [JsonProperty("bitcoin")]
        public BitcoinData Bitcoin { get; set; }

        public class BitcoinData
        {
            [JsonProperty("usd")]
            public double Usd { get; set; }

            [JsonProperty("usd_24h_change")]
            public double Usd24hChange { get; set; }
        }
    }
}
