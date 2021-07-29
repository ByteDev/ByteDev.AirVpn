namespace ByteDev.AirVpn.Contract.Request
{
    /// <summary>
    /// Represents a send notification request.
    /// </summary>
    public class SendNotificationRequest : AuthenticatedApiRequest
    {
        /// <summary>
        /// Subject text for the notification.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Body text for the notification.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.Contract.Request.SendNotificationRequest" /> class.
        /// </summary>
        /// <param name="apiKey">AirVPN API key.</param>
        /// <exception cref="T:System.ArgumentException"><paramref name="apiKey" /> is null or empty.</exception>
        public SendNotificationRequest(string apiKey) : base(apiKey)
        {
        }
    }
}