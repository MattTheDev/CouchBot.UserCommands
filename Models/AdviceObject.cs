using Newtonsoft.Json;

namespace CouchBot.UserCommands.Models
{
    public class AdviceObject
    {
        [JsonProperty("slip")]
        public Advice AdviceSlip { get; set; }

        public class Advice
        {
            [JsonProperty("id")]
            public string AdviceiD { get; set; }

            [JsonProperty("advice")]
            public string AdviceText { get; set; }
        }
    }
}
