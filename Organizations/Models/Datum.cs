using Newtonsoft.Json;

namespace Organizations.Models
{
    public class Datum
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameid")]
        public string NameId { get; set; }
    }
}