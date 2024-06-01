using System.Net.Http;

namespace MauiSqlite.Models
{
    public class ApiHelper
    {
        static readonly string Url = $"https://api.sunrisesunset.io/json?lat=38.907192&lng=-77.036873";
        private static string authorizationkey;
        static HttpClient client;

        // basic needs of an api call
        private static async Task<HttpClient> GetClient()
        {
            if (client != null)
            {
                return client;
            }

            client = new HttpClient();

            if (string.IsNullOrEmpty(authorizationkey))
            {
                authorizationkey = await client.GetStringAsync($"");
            }

            return client;
        }

    }
}
