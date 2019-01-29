using System.Collections.Generic;

namespace Organizations.Models
{
    public class Organization
    {
        public string Name { get; set; }
        public List<Repository> Repositories { get; set; }
    }
}