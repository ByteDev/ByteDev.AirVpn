using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.Contract.Response
{
    public class GetStatusCountryResponse : BaseStatusEntryResponse
    {
        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// The currently recommended server.
        /// </summary>
        [JsonPropertyName("server_best")]
        public string BestServer { get; set; }

        /// <summary>
        /// Number of users.
        /// </summary>
        [JsonPropertyName("users")]
        public int Users { get; set; }

        [JsonPropertyName("servers")]
        public int Servers { get; set; }
    }
}