using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.Contract.Response
{
    public abstract class BaseStatusResponse
    {
        /// <summary>
        /// Percentage of the current load.
        /// </summary>
        [JsonPropertyName("currentload")]
        public int CurrentLoad { get; set; }

        /// <summary>
        /// Health status.
        /// </summary>
        [JsonPropertyName("health")]
        public string HealthStatus { get; set; }

        /// <summary>
        /// Health warning message. Only set if health is at warning.
        /// </summary>
        [JsonPropertyName("warning")]
        public string HealthWarning { get; set; }

        /// <summary>
        /// Bandwidth used in Mbits a second.
        /// </summary>
        [JsonPropertyName("bw")]
        public int BandwidthUsed { get; set; }

        /// <summary>
        /// Bandwidth available in Mbits a second.
        /// </summary>
        [JsonPropertyName("bw_max")]
        public int BandwidthAvailable { get; set; }

        /// <summary>
        /// Health status as a enumeration.
        /// </summary>
        [JsonIgnore]
        public HealthStatusType HealthStatusType
        {
            get
            {
                switch (HealthStatus)
                {
                    case "ok":
                        return HealthStatusType.Ok;
                    case "warning":
                        return HealthStatusType.Warning;
                    case "error":
                        return HealthStatusType.Error;
                    default:
                        return HealthStatusType.Unknown;
                }
            }
        }
    }
}