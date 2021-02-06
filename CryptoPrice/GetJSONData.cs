using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptoPrice
{
    public class GetJSONData
    {
        [JsonProperty("Realtime Currency Exchange Rate")]
        public Rate LiveData { get; set; }

        public class Rate
        {
            [JsonProperty("5. Exchange Rate")]
            public string ExchangeRate { get; set; }
            [JsonProperty("6. Last Refreshed")]
            public string Date { get; set; }
        }

    }
}
