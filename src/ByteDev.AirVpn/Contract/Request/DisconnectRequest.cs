namespace ByteDev.AirVpn.Contract.Request
{
    /// <summary>
    /// Represents a request for disconnection from the VPN.
    /// </summary>
    public class DisconnectRequest : AuthenticatedApiRequest
    {
        /// <summary>
        /// Optional. If specified disconnects only sessions related to this server name.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Optional. If specified disconnects only sessions related to this device name.
        /// </summary>
        public string Device { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.Contract.Request.DisconnectRequest" /> class.
        /// </summary>
        /// <param name="apiKey">AirVPN API key.</param>
        /// <exception cref="T:System.ArgumentException"><paramref name="apiKey" /> is null or empty.</exception>
        public DisconnectRequest(string apiKey) : base(apiKey)
        {
        }
    }
}