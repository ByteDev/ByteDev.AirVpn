using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.Contract.Response
{
    public class GetStatusServerResponse : BaseStatusEntryResponse
    {
        [JsonPropertyName("public_name")]
        public string PublicName { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("continent")]
        public string Continent { get; set; }

        /// <summary>
        /// Number of users.
        /// </summary>
        [JsonPropertyName("users")]
        public int Users { get; set; }
    }
}