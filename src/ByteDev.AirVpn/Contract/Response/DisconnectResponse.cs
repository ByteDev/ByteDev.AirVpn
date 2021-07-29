using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.Contract.Response
{
    /// <summary>
    /// Represents a disconnect request from the AirVPN API.
    /// </summary>
    public class DisconnectResponse : BaseApiResponse
    {
        /// <summary>
        /// Number of sessions to be disconnected.
        /// </summary>
        [JsonPropertyName("sessions_disconnected")]
        public int SessionsDisconnecting { get; set; }
    }
}