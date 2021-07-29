using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.Contract.Response
{
    public abstract class BaseStatusEntryResponse : BaseStatusResponse
    {
        [JsonPropertyName("ip_v4_in1")]
        public string IpV4Entry1 { get; set; }

        [JsonPropertyName("ip_v4_in2")]
        public string IpV4Entry2 { get; set; }

        [JsonPropertyName("ip_v4_in3")]
        public string IpV4Entry3 { get; set; }

        [JsonPropertyName("ip_v4_in4")]
        public string IpV4Entry4 { get; set; }

        [JsonPropertyName("ip_v6_in1")]
        public string IpV6Entry1 { get; set; }

        [JsonPropertyName("ip_v6_in2")]
        public string IpV6Entry2 { get; set; }

        [JsonPropertyName("ip_v6_in3")]
        public string IpV6Entry3 { get; set; }

        [JsonPropertyName("ip_v6_in4")]
        public string IpV6Entry4 { get; set; }
    }
}