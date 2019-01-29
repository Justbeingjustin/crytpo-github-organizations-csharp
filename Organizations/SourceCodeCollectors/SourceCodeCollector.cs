using Organizations.Extensions;
using System.Linq;

namespace Organizations.SourceCodeCollectors
{
    /// <summary>
    /// Given a html page from coinlore, this class collects the github source code URL
    /// </summary>
    public class SourceCodeCollector
    {
        private readonly string _html;

        public SourceCodeCollector(string html)
        {
            _html = html;
        }

        public string CollectSourceCodeURL()
        {
            var remainingText = _html.Substring(_html.IndexOf("mdi mdi-source-branch"));

            remainingText = remainingText.Between("<a href=\"", " target=");

            if (remainingText.Substring(remainingText.Length - 1) == "\"")
            {
                remainingText = remainingText.Substring(0, remainingText.Length - 1);
            }

            if (remainingText.Substring(remainingText.Length - 1) == "\\")
            {
                remainingText = remainingText.Substring(0, remainingText.Length - 1);
            }

            if (remainingText.Count(x => x == '/') >= 4)
            {
                remainingText = remainingText.Substring(0, remainingText.NthIndexOf("/", 4));
            }

            return remainingText;
        }
    }
}