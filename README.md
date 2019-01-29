# crytpo-github-organizations-csharp

This library collects github repository urls for the top 100 crypto organizations.

# ![Logo](Images/github.png) 

### Table of Contents
**[Available For](#available-for)**<br>
**[Nuget](#nuget)**<br>
**[Usage](#usage)**<br>
**[Contributing](#contributing)**<br>


## Available For
- .NET Standard 2.0
- .NET 4.6.1
- .NET 4.5


## Nuget

 ```
    PM> Install-Package github-repository-csharp
```
[![](https://img.shields.io/nuget/v/crytpo-github-organizations-csharp.svg)](https://www.nuget.org/packages/crytpo-github-organizations-csharp/)\
[![](https://img.shields.io/nuget/dt/crytpo-github-organizations-csharp.svg)](https://www.nuget.org/packages/crytpo-github-organizations-csharp/)




## Usage

```csharp
using Github;
using System;
using Organizations;

namespace ConsoleApp13
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var organizationCoordinator = new OrganizationsCoordinator();
            var organizations = organizationCoordinator.GetOrganizations();
        }
    }
}
```

## Contributing

Pull requests are welcome. 

For large changes, please open an issue first to discuss what you would like to add.
