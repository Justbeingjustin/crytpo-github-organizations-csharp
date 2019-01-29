using Newtonsoft.Json;
using Organizations.Models;
using RestSharp;

namespace Organizations.CryptoNamesCollectors
{
    /// <summary>
    /// Gets the name of the top 100 cryptos from coinlore.com
    /// </summary>
    public class CryptoNamesCollector
    {
        public CryptoNamesCollector()
        {
        }

        public CryptoNamesContainer GetCryptoNames()
        {
            var client = new RestClient("https://api.coinlore.com/api/tickers/");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<CryptoNamesContainer>(response.Content);
        }
    }
}