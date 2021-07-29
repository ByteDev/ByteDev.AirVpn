using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ByteDev.AirVpn.Contract.Request;
using ByteDev.AirVpn.Contract.Response;

namespace ByteDev.AirVpn
{
    /// <summary>
    /// Represents a client for talking to the AirVPN API.
    /// </summary>
    public class AirVpnClient : IAirVpnClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.AirVpnClient" /> class.
        /// </summary>
        /// <param name="httpClient">Instance of HttpClient to use when communicating with the API.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="httpClient" /> is null.</exception>
        public AirVpnClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Retrieve user information. User is determined based on the provided API key.
        /// This information will include session information if the user is currently connected to the VPN.
        /// </summary>
        /// <param name="request">Get user request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A cancellation token that can be used by other objects or threads to receive notice of cancellation. Result will contain response information.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="request" /> is null.</exception>
        /// <exception cref="T:ByteDev.AirVpn.AirVpnClientException">Error occurred while performing the request.</exception>
        public async Task<GetUserResponse> GetUserAsync(GetUserRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null) 
                throw new ArgumentNullException(nameof(request));

            try
            {
                var uri = ApiUriFactory.CreateGetUserInfo(request);

                var response = await _httpClient.GetAsync(uri, cancellationToken);
                
                return await ApiResponseHandler.HandleAsync<GetUserResponse>(response);
            }
            catch (Exception ex)
            {
                throw new AirVpnClientException("Error occured while retrieving user info.", ex);
            }
        }

        /// <summary>
        /// Send a notification to the user. User is determined based on the provided API key.
        /// </summary>
        /// <param name="request">Send notification request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A cancellation token that can be used by other objects or threads to receive notice of cancellation. Result will contain response information.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="request" /> is null.</exception>
        /// <exception cref="T:ByteDev.AirVpn.AirVpnClientException">Error occurred while performing the request.</exception>
        public async Task<SendNotificationResponse> SendNotificationAsync(SendNotificationRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null) 
                throw new ArgumentNullException(nameof(request));

            try
            {
                var uri = ApiUriFactory.CreateSendNotification(request);

                var response = await _httpClient.GetAsync(uri, cancellationToken);
                
                return await ApiResponseHandler.HandleAsync<SendNotificationResponse>(response);
            }
            catch (Exception ex)
            {
                throw new AirVpnClientException("Error occured while sending notification.", ex);
            }
        }

        /// <summary>
        /// Request that the users current VPN connection be disconnected. User is determined based on the provided API key.
        /// If none of the optional request properties are set then all the user's sessions.
        /// </summary>
        /// <param name="request">Disconnect request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A cancellation token that can be used by other objects or threads to receive notice of cancellation. Result will contain response information.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="request" /> is null.</exception>
        /// <exception cref="T:ByteDev.AirVpn.AirVpnClientException">Error occurred while performing the request.</exception>
        public async Task<DisconnectResponse> DisconnectAsync(DisconnectRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null) 
                throw new ArgumentNullException(nameof(request));

            try
            {
                var uri = ApiUriFactory.CreateDisconnect(request);

                var response = await _httpClient.GetAsync(uri, cancellationToken);
                
                return await ApiResponseHandler.HandleAsync<DisconnectResponse>(response);
            }
            catch (Exception ex)
            {
                throw new AirVpnClientException("Error occured while attempting to disconnect from the VPN.", ex);
            }
        }

        /// <summary>
        /// Retrieves status information about servers on the VPN. Does not require an API key.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A cancellation token that can be used by other objects or threads to receive notice of cancellation. Result will contain response information.</returns>
        /// <exception cref="T:ByteDev.AirVpn.AirVpnClientException">Error occurred while performing the request.</exception>
        public async Task<GetStatusResponse> GetStatusAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var uri = ApiUriFactory.CreateGetStatus();

                var response = await _httpClient.GetAsync(uri, cancellationToken);
                
                return await ApiResponseHandler.HandleAsync<GetStatusResponse>(response);
            }
            catch (Exception ex)
            {
                throw new AirVpnClientException("Error occured while retrieving status info.", ex);
            }
        }
    }
}