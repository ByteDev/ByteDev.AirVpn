using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.Contract.Response
{
    /// <summary>
    /// Represents a response from the AirVPN API.
    /// </summary>
    public abstract class BaseApiResponse
    {
        /// <summary>
        /// Indicates if the requests was not successful. If false then property
        /// ErrorMessage should be populated.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccessful => Result == "ok";

        /// <summary>
        /// Result of the request as reported back from the API.
        /// </summary>
        [JsonPropertyName("result")]
        public string Result { get; set; }

        /// <summary>
        /// Any error message returned from the API for the request.
        /// </summary>
        [JsonPropertyName("error")]
        public string ErrorMessage { get; set; }
    }
}