using System.Threading;
using System.Threading.Tasks;
using ByteDev.AirVpn.Contract.Request;
using ByteDev.AirVpn.Contract.Response;

namespace ByteDev.AirVpn
{
    public interface IAirVpnClient
    {
        /// <summary>
        /// Retrieve user information. User is determined based on the provided API key.
        /// This information will include session information if the user is currently connected to the VPN.
        /// </summary>
        /// <param name="request">Get user request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A cancellation token that can be used by other objects or threads to receive notice of cancellation. Result will contain response information.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="request" /> is null.</exception>
        /// <exception cref="T:ByteDev.AirVpn.AirVpnClientException">Error occurred while performing the request.</exception>
        Task<GetUserResponse> GetUserAsync(GetUserRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send a notification to the user. User is determined based on the provided API key.
        /// </summary>
        /// <param name="request">Send notification request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A cancellation token that can be used by other objects or threads to receive notice of cancellation. Result will contain response information.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="request" /> is null.</exception>
        /// <exception cref="T:ByteDev.AirVpn.AirVpnClientException">Error occurred while performing the request.</exception>
        Task<SendNotificationResponse> SendNotificationAsync(SendNotificationRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Request that the users current VPN connection be disconnected. User is determined based on the provided API key.
        /// </summary>
        /// <param name="request">Disconnect request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A cancellation token that can be used by other objects or threads to receive notice of cancellation. Result will contain response information.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="request" /> is null.</exception>
        /// <exception cref="T:ByteDev.AirVpn.AirVpnClientException">Error occurred while performing the request.</exception>
        Task<DisconnectResponse> DisconnectAsync(DisconnectRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves status information about servers on the VPN. Does not require an API key.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A cancellation token that can be used by other objects or threads to receive notice of cancellation. Result will contain response information.</returns>
        /// <exception cref="T:ByteDev.AirVpn.AirVpnClientException">Error occurred while performing the request.</exception>
        Task<GetStatusResponse> GetStatusAsync(CancellationToken cancellationToken = default);
    }
}