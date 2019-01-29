using Organizations.CryptoNamesCollectors;
using Organizations.Models;
using Organizations.RepositoriesCollectors;
using Organizations.Services;
using Organizations.SourceCodeCollectors;
using System;
using System.Collections.Generic;

namespace Organizations
{
    public class OrganizationsCoordinator
    {
        public List<Organization> GetOrganizations()
        {
            List<Organization> organizations = new List<Organization>();
            var organizationDetails = GetOrganizationDetails(new CryptoNamesCollector().GetCryptoNames());

            foreach (var organzationDetail in organizationDetails)
            {
                try
                {
                    organizations.Add(
                        new Organization()
                        {
                            Repositories = new RepositoriesCollector(organzationDetail.SourceCodeURL.Replace("https://github.com/", "")).GetRepositories(),
                            Name = organzationDetail.OrganizationName
                        });
                }
                catch (Exception ex)
                {
                    //repo doesn't exist
                }
            }

            return organizations;
        }

        private List<OrganizationDetails> GetOrganizationDetails(CryptoNamesContainer cryptoNames)
        {
            List<OrganizationDetails> organizationDetails = new List<OrganizationDetails>();
            foreach (var crypto in cryptoNames.Data)
            {
                try
                {
                    organizationDetails.Add(new OrganizationDetails()
                    {
                        OrganizationName = crypto.Name,
                        SourceCodeURL = new SourceCodeCollector(new HTMLCollector("https://www.coinlore.com/coin/" + crypto.NameId).CollectHTML()).CollectSourceCodeURL()
                    });
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    // there is no source code for this repo...
                }
                catch (System.Net.WebException ex)
                {
                    // too many requests per second
                    throw new Exception("hitting coinlore too often. consider sleeping more!");
                }
            }
            return organizationDetails;
        }
    }
}