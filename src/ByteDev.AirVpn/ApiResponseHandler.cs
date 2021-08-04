using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ByteDev.AirVpn.Contract.Response;
using ByteDev.Json.SystemTextJson.Serialization;

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
            options.Converters.Add(new UnixEpochTimeToDateTimeJsonConverter
            {
                Precision = UnixEpochTimePrecision.Seconds
            });
            options.Converters.Add(new EnumJsonConverter<HealthStatusType>(HealthStatusType.Unknown)
            {
                WriteEnumValueType = EnumValueType.Name
            });

            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}