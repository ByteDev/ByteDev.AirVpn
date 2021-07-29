namespace ByteDev.AirVpn.Contract.Request
{
    /// <summary>
    /// Represents a request to retrieve user information.
    /// </summary>
    public class GetUserRequest : AuthenticatedApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.Contract.Request.GetUserRequest" /> class.
        /// </summary>
        /// <param name="apiKey">AirVPN API key.</param>
        /// <exception cref="T:System.ArgumentException"><paramref name="apiKey" /> is null or empty.</exception>
        public GetUserRequest(string apiKey) : base(apiKey)
        {
        }
    }
}