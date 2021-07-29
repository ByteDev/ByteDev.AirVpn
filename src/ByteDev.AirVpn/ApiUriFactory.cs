using System;
using System.Collections.Specialized;
using ByteDev.AirVpn.Contract.Request;
using ByteDev.ResourceIdentifier;

namespace ByteDev.AirVpn
{
    internal static class ApiUriFactory
    {
        private const string BaseUri = "https://airvpn.org/api/";

        public static Uri CreateGetUserInfo(AuthenticatedApiRequest request)
        {
            // https://airvpn.org/api/userinfo/?format=json&key=<key>

            return new Uri(BaseUri)
                .AppendPath("userinfo/")
                .AddOrUpdateQueryParams(new NameValueCollection
                {
                    { "format", "json" },
                    { "key", request.ApiKey }
                });
        }

        public static Uri CreateSendNotification(SendNotificationRequest request)
        {
            // https://airvpn.org/api/notification/?format=json&key=<key>&subject=<subject>&body=<body>

            return new Uri(BaseUri)
                .AppendPath("notification/")
                .AddOrUpdateQueryParams(new NameValueCollection
                {
                    { "format", "json" },
                    { "key", request.ApiKey },
                    { "subject", request.Subject },
                    { "body", request.Body }
                });
        }

        public static Uri CreateDisconnect(DisconnectRequest request)
        {
            // https://airvpn.org/api/disconnect/?format=json&key=<key>

            var uri = new Uri(BaseUri)
                .AppendPath("disconnect/")
                .AddOrUpdateQueryParams(new NameValueCollection
                {
                    { "format", "json" },
                    { "key", request.ApiKey }
                });

            if (!string.IsNullOrEmpty(request.Server))
            {
                uri = uri.AddOrUpdateQueryParam("server", request.Server);
            }

            if (!string.IsNullOrEmpty(request.Device))
            {
                uri = uri.AddOrUpdateQueryParam("device", request.Device);
            }

            return uri;
        }

        public static Uri CreateGetStatus()
        {
            // https://airvpn.org/api/status/?format=json

            return new Uri(BaseUri)
                .AppendPath("status/")
                .AddOrUpdateQueryParam("format", "json");
        }
    }
}