using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Services.InMemory;
using IdentityModel;
using System.Security.Claims;

namespace Models
{
    public static class Users
    {
        public static IEnumerable<InMemoryUser> Get()
        {
            yield return new InMemoryUser
            {
                Subject = "818727",
                Username = "alice",
                Password = "alice",
                Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "Alice Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Alice"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "Admin"),
                        new Claim(JwtClaimTypes.Role, "Geek"),
                        new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", Constants.ClaimValueTypes.Json)
                    }
            };
        }

    }
}
