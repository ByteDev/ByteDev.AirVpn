using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.Contract.Response
{
    /// <summary>
    /// Represents information about a user of AirVPN.
    /// </summary>
    public class GetUserResponse : BaseApiResponse
    {
        private IEnumerable<GetUserSessionResponse> _sessions;

        /// <summary>
        /// User details.
        /// </summary>
        [JsonPropertyName("user")]
        public GetUserInfoResponse User { get; set; }
        
        /// <summary>
        /// Details of all the user's AirVPN sessions on all devices.
        /// </summary>
        [JsonPropertyName("sessions")]
        public IEnumerable<GetUserSessionResponse> Sessions
        {
            get => _sessions ?? (_sessions = Enumerable.Empty<GetUserSessionResponse>());
            set => _sessions = value;
        }
    }
}