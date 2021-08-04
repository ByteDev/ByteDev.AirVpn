using System;
using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.Contract.Response
{
    /// <summary>
    /// Represents details about a particular user session.
    /// </summary>
    public class GetUserSessionResponse
    {
        [JsonPropertyName("device_name")]
        public string DeviceName { get; set; }

        [JsonPropertyName("device_description")]
        public string DeviceDescription { get; set; }

        /// <summary>
        /// Local IP address assigned (10.*)
        /// </summary>
        [JsonPropertyName("vpn_ip")]
        public string VpnIp { get; set; }

        [JsonPropertyName("vpn_ipv4")]
        public string VpnIpV4 { get; set; }

        [JsonPropertyName("vpn_ipv6")]
        public string VpnIpV6 { get; set; }

        [JsonPropertyName("exit_ip")]
        public string ExitIp { get; set; }

        [JsonPropertyName("exit_ipv4")]
        public string ExitIpV4 { get; set; }

        [JsonPropertyName("exit_ipv6")]
        public string ExitIpV6 { get; set; }

        [JsonPropertyName("entry_ip")]
        public string EntryIp { get; set; }

        [JsonPropertyName("entry_ipv4")]
        public string EntryIpV4 { get; set; }

        [JsonPropertyName("entry_ipv6")]
        public string EntryIpV6 { get; set; }
        
        [JsonPropertyName("server_name")]
        public string ServerName { get; set; }

        [JsonPropertyName("server_country")]
        public string ServerCountry { get; set; }

        [JsonPropertyName("server_country_code")]
        public string ServerCountryCode { get; set; }

        [JsonPropertyName("server_continent")]
        public string ServerContinent { get; set; }

        [JsonPropertyName("server_location")]
        public string ServerLocation { get; set; }

        /// <summary>
        /// Server bandwidth in Mbits.
        /// </summary>
        [JsonPropertyName("server_bw")]
        public string ServerBandwidth { get; set; }

        /// <summary>
        /// Bytes read in the current session.
        /// </summary>
        [JsonPropertyName("bytes_read")]
        public string BytesRead { get; set; }

        /// <summary>
        /// Bytes written in the current session.
        /// </summary>
        [JsonPropertyName("bytes_write")]
        public string BytesWrite { get; set; }

        /// <summary>
        /// Date time the current connnection started.
        /// </summary>
        [JsonPropertyName("connected_since_unix")]
        public DateTime ConnectedSinceDateTime { get; set; }

        /// <summary>
        /// Read bytes per second.
        /// </summary>
        [JsonPropertyName("speed_read")]
        public string SpeedRead { get; set; }

        /// <summary>
        /// Written bytes per second.
        /// </summary>
        [JsonPropertyName("speed_write")]
        public string SpeedWrite { get; set; }
    }
}