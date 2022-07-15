using Newtonsoft.Json;

namespace Display.Core.Services.Bridge.Stellar.HttpClient;

public static class StellarClient
{
    public static async Task<dynamic?> GetAsync(string uri)
    {
        try
        {
            using var client = new System.Net.Http.HttpClient
            {
                Timeout = TimeSpan.FromSeconds(3),
                BaseAddress = new Uri("https://api.bridgedataoutput.com/api/")
            };
            
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(json);
            return result;
        }
        catch (Exception)
        {
            //ToDo: log this
            return null;
        }
    }
}