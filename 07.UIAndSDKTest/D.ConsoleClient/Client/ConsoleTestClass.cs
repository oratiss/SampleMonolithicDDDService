using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    public class ConsoleTestClass
    {
        public async Task<bool> DoCheckMEtadata()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return false;
            }

            return true;
        }
        
        public async Task<bool> DoCheckAccessToken()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "AngularFrontClient",
                ClientSecret = "AngularFrontSecret",
                Scope = "WebApi"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return false;
            }

            return true;
        }
        
        public async Task<bool> DocheckCallingApi()
        {   //arrange
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "AngularFrontClient",
                ClientSecret = "AngularFrontSecret",
                Scope = "WebApi"
            });
            
            //act
            // call api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            //var response = await apiClient.GetAsync("https://localhost:6001/identity");
            var response = await apiClient.GetAsync("https://localhost:44332/identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                return false;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
                return true;
            }
        }
        
        
    }
}
