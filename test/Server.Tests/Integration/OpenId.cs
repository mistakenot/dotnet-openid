using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using IdentityModel.Client;

namespace Server.Api.Tests
{
    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dotnet-core.html
    public class OpenIdTests
    {
        private readonly TokenClient _tokenClient;
        private readonly string _endpoint = "http://localhost:5000/";

        public OpenIdTests()
        {
            _tokenClient = new TokenClient(
              "http://localhost:5000/connect/token",
              "js",
              "secret"
            );
        }

        [Fact]
        public void GetToken()
        {
            var result = _tokenClient.RequestResourceOwnerPasswordAsync("alice", "alice", "openid").Result;

            Console.WriteLine(result.Json.ToString());
            Assert.False(result.IsError);
            Assert.Null(result.Error);

            var userInfo = new UserInfoClient(new Uri(_endpoint + "connect/userinfo"), result.AccessToken)
              .GetAsync()
              .Result;

            Console.WriteLine(userInfo.HttpErrorReason);
            Assert.False(userInfo.IsError);
        }
    }

}
