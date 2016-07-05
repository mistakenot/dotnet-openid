using System.Collections.Generic;
using IdentityServer4.Models;

namespace Models {

  public class Clients
  {
    public static IEnumerable<Client> Get()
        {
            yield return new Client
            {
                ClientId = "js",
                ClientName = "Javascript Web Client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                Enabled = true,

                AccessTokenType = AccessTokenType.Reference,

                ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name,
                        "api1"
                    }
            };
        }
  }
}
