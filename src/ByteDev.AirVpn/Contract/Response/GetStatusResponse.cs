using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.Contract.Response
{
    /// <summary>
    /// Represents a response from a request to retrieve status information about the servers
    /// within AirVPN.
    /// </summary>
    public class GetStatusResponse : BaseApiResponse
    {
        private IEnumerable<GetStatusServerResponse> _servers;
        private IEnumerable<GetStatusRouteResponse> _routes;
        private IEnumerable<GetStatusCountryResponse> _countries;
        private IEnumerable<GetStatusContinentResponse> _continents;
        private IEnumerable<GetStatusPlanetResponse> _planets;

        [JsonPropertyName("servers")]
        public IEnumerable<GetStatusServerResponse> Servers
        {
            get => _servers ?? (_servers = Enumerable.Empty<GetStatusServerResponse>());
            set => _servers = value;
        }

        [JsonPropertyName("routing")]
        public IEnumerable<GetStatusRouteResponse> Routes
        {
            get => _routes ?? (_routes = Enumerable.Empty<GetStatusRouteResponse>());
            set => _routes = value;
        }

        [JsonPropertyName("countries")]
        public IEnumerable<GetStatusCountryResponse> Countries
        {
            get => _countries ?? (_countries = Enumerable.Empty<GetStatusCountryResponse>());
            set => _countries = value;
        }

        [JsonPropertyName("continents")]
        public IEnumerable<GetStatusContinentResponse> Continents
        {
            get => _continents ?? (_continents = Enumerable.Empty<GetStatusContinentResponse>());
            set => _continents = value;
        }

        [JsonPropertyName("planets")]
        public IEnumerable<GetStatusPlanetResponse> Planets
        {
            get => _planets ?? (_planets = Enumerable.Empty<GetStatusPlanetResponse>());
            set => _planets = value;
        }
    }
}