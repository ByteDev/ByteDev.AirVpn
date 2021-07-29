using ByteDev.Testing;

namespace ByteDev.AirVpn.IntTests
{
    internal static class TestApiKeys
    {
        private static string _apiKey;

        public static readonly string Invalid = "notValidKey111";

        public static string Valid
        {
            get
            {
                if (!string.IsNullOrEmpty(_apiKey))
                    return _apiKey;

                var testApiKey = new TestApiKey();
                testApiKey.FilePaths.Add(@"Z:\ByteDev.AirVpn.IntTests.apikey");

                _apiKey = testApiKey.GetValue();

                return _apiKey;
            }
        }
    }
}