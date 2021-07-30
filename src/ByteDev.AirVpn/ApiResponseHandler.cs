using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ByteDev.AirVpn.Json;

namespace ByteDev.AirVpn
{
    internal static class ApiResponseHandler
    {
        public static async Task<T> HandleAsync<T>(HttpResponseMessage response) where T : class
        {
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new AirVpnClientException($"AirVPN API request was not successful. Response status code: '{response.StatusCode}'. Response content: '{json}'.");
            }

            var options = new JsonSerializerOptions();
            options.Converters.Add(new UnixEpochTimeToDateTimeJsonConverter());

            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}