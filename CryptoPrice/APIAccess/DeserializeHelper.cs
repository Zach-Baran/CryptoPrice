using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPrice.APIAccess
{
    public class DeserializeHelper
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
