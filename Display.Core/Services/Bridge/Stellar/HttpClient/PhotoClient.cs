namespace Display.Core.Services.Bridge.Stellar.HttpClient;

public static class PhotoClient
{
    public static async Task<byte[]?> GetAsync(string uri)
    {
        try
        {
            using var client = new System.Net.Http.HttpClient
            {
                Timeout = TimeSpan.FromSeconds(3),
                BaseAddress = new Uri("https://dvvjkgh94f2v6.cloudfront.net")
            };
            
            using var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsByteArrayAsync();
            return result;
        }
        catch (Exception)
        {
            //ToDo: log this
            return null;
        }
    }
}