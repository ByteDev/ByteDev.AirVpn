using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.Contract.Response
{
    /// <summary>
    /// Represents details about a particular user.
    /// </summary>
    public class GetUserInfoResponse
    {
        // TODO: remove unix time and replace with DateTime

        /// <summary>
        /// Login user name.
        /// </summary>
        [JsonPropertyName("login")]
        public string Login { get; set; }

        /// <summary>
        /// Date of registration on the website.
        /// </summary>
        [JsonPropertyName("register_date")]
        public string RegisterDateTime { get; set; }

        /// <summary>
        /// Date of registration on the website.
        /// </summary>
        [JsonPropertyName("register_unix")]
        public int RegisterDateTimeUnix { get; set; }

        /// <summary>
        /// Indicates if account is premium.
        /// </summary>
        [JsonPropertyName("premium")]
        public bool IsPremium { get; set; }
        
        /// <summary>
        /// Date time of expiration.
        /// </summary>
        [JsonPropertyName("expiration_date")]
        public string ExpirationDateTime { get; set; }

        /// <summary>
        /// Unix date time of expiration.
        /// </summary>
        [JsonPropertyName("expiration_unix")]
        public int ExpirationDateTimeUnix { get; set; }

        /// <summary>
        /// Forum post count.
        /// </summary>
        [JsonPropertyName("posts")]
        public string PostsCount { get; set; }

        /// <summary>
        /// Date time of last forum post.
        /// </summary>
        [JsonPropertyName("last_post")]
        public string LastPostDateTime { get; set; }

        /// <summary>
        /// Date time of last visit to the website.
        /// </summary>
        [JsonPropertyName("last_visit_unix")]
        public int LastVisitDateTimeUnix { get; set; }

        /// <summary>
        /// Unix date time of last activity on website.
        /// </summary>
        [JsonPropertyName("last_activity_unix")]
        public int LastActivityDateTimeUnix { get; set; }

        /// <summary>
        /// Unix date time of last attempt to connect to a VPN server.
        /// </summary>
        [JsonPropertyName("last_attempt_unix")]
        public int LastAttemptDateTimeUnix { get; set; }

        /// <summary>
        /// Account credits.
        /// </summary>
        [JsonPropertyName("credits")]
        public int CreditsCount { get; set; }

        /// <summary>
        /// Indicates if the user is connected to the VPN.
        /// </summary>
        [JsonPropertyName("connected")]
        public bool IsConnected { get; set; }
    }
}