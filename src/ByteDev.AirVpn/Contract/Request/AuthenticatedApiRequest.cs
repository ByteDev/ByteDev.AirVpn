using System;

namespace ByteDev.AirVpn.Contract.Request
{
    /// <summary>
    /// Represents a request to the AirVPN API that requires an API key.
    /// </summary>
    public abstract class AuthenticatedApiRequest
    {
        public string ApiKey { get; }

        protected AuthenticatedApiRequest(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException("API key was null or empty.", nameof(apiKey));

            ApiKey = apiKey;
        }
    }
}