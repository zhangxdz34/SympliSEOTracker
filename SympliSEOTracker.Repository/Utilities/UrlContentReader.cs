namespace SympliSEOTracker.Repository
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Utility class to read url content as byte array
    /// eg. Get document content/signature content in MESH sync
    /// </summary>
    public class UrlContentReader
    {
        private static HttpClient _client;

        private static HttpClient client
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient();
                }

                return _client;
            }
        }

        public async Task<string> GetUrlContentAsync(string requestUri)
        {
            if (string.IsNullOrEmpty(requestUri))
            {
                return null;
            }

            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);

                HttpResponseMessage response = await client.SendAsync(requestMessage);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
