using Newtonsoft.Json;
using Organizations.Models;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace Organizations.RepositoriesCollectors
{
    /// <summary>
    /// given a github organization name, this class will return all of the repositories
    /// </summary>
    public class RepositoriesCollector
    {
        private readonly string _organizationName;

        public RepositoriesCollector(string organizationName)
        {
            _organizationName = organizationName;
        }

        public List<Repository> GetRepositories()
        {
            var repositories = new List<Repository>();
            int pageCount = 1;
            while (true)
            {
                var repos = GetRepositoriesByPage(pageCount);
                if (repos.Count == 0)
                {
                    break;
                }
                repositories = repositories.Union(repos).ToList();
                pageCount += 1;
            }
            return repositories;
        }

        private List<Repository> GetRepositoriesByPage(int pageNumber)
        {
            System.Threading.Thread.Sleep(1000);
            var client = new RestClient("https://api.github.com/orgs/" + _organizationName + "/repos?page=" + pageNumber);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var repositories = JsonConvert.DeserializeObject<List<GithubRepositories>>(response.Content);

            var repos = new List<Repository>();

            foreach (var repository in repositories)
            {
                repos.Add(new Repository()
                {
                    RepositoryURL = repository.HTML_URL,
                });
            }
            return repos;
        }
    }
}