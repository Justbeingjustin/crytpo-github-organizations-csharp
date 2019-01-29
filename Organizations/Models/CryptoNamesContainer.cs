using Newtonsoft.Json;
using System.Collections.Generic;

namespace Organizations.Models
{
    public class CryptoNamesContainer
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }
    }
}