using IdentityServer4.Models;

namespace IdentityServer;

public partial class Program
{
    public class Config
    {
        public static IEnumerable<Client> GetAllApiClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "PresentationWebApi" }
                }
            };
        }

        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("Presentation.Web.Api", "Note Taking Web API")
            };
        }

        public static IEnumerable<ApiScope> GetAllScopes()
        {
           return new List<ApiScope>()
           {
               new ApiScope()
               {
                   Name = "PresentationWebApi",
                   Emphasize=true,
               },
               new ApiScope
               {
                   Name = "Presentation.Web.Api",
                   Emphasize=true,
               },
           };
        }
    }
}
