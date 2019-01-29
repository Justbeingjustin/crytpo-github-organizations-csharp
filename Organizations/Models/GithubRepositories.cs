using Newtonsoft.Json;

namespace Organizations.Models
{
    public class GithubRepositories
    {
        [JsonProperty("html_url")]
        public string HTML_URL { get; set; }
    }
}