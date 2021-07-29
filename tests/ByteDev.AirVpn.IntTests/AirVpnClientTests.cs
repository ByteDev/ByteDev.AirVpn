using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ByteDev.AirVpn.Contract.Request;
using NUnit.Framework;

namespace ByteDev.AirVpn.IntTests
{
    [TestFixture]
    public class AirVpnClientTests
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private AirVpnClient _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new AirVpnClient(HttpClient);
        }

        [TestFixture]
        public class GetUserInfoAsync : AirVpnClientTests
        {
            [Test]
            public async Task WhenApiKeyIsInvalid_ThenReturnResponse()
            {
                var result = await _sut.GetUserAsync(new GetUserRequest(TestApiKeys.Invalid));

                Assert.That(result.IsSuccessful, Is.False);
                Assert.That(result.ErrorMessage, Is.EqualTo("Not authorized"));
            }

            [Test]
            public async Task WhenApiKeyIsValid_AndNotConnectedToVpn_ThenReturnResponse()
            {
                var result = await _sut.GetUserAsync(new GetUserRequest(TestApiKeys.Valid));
                
                Assert.That(result.IsSuccessful, Is.True);
                Assert.That(result.User.IsConnected, Is.False);
                Assert.That(result.Sessions.Count(), Is.EqualTo(0));
            }

            [Test]
            [Ignore("Run ad-hoc. Need to be connected to AirVPN.")]
            public async Task WhenApiKeyIsValid_AndConnectedToVpn_ThenReturnResponse()
            {
                var result = await _sut.GetUserAsync(new GetUserRequest(TestApiKeys.Valid));

                Assert.That(result.IsSuccessful, Is.True);
                Assert.That(result.User.IsConnected, Is.True);
                Assert.That(result.Sessions.Count(), Is.GreaterThan(0));
            }
        }

        [TestFixture]
        public class SendNotificationAsync : AirVpnClientTests
        {
            [Test]
            public async Task WhenApiKeyIsInvalid_ThenReturnResponse()
            {
                var result = await _sut.SendNotificationAsync(new SendNotificationRequest(TestApiKeys.Invalid)
                {
                    Subject = "TestSubject",
                    Body = "TestBody"
                });

                Assert.That(result.IsSuccessful, Is.False);
                Assert.That(result.ErrorMessage, Is.EqualTo("Not authorized"));
            }

            [Test]
            public async Task WhenApiKeyIsValid_AndNotConnectedToVpn_ThenReturnResponse()
            {
                var result = await _sut.SendNotificationAsync(new SendNotificationRequest(TestApiKeys.Valid)
                {
                    Subject = "TestSubject",
                    Body = "TestBody"
                });

                Assert.That(result.IsSuccessful, Is.True);
                Assert.That(result.ErrorMessage, Is.Null);
            }
        }

        [TestFixture]
        public class DisconnectAsync : AirVpnClientTests
        {
            [Test]
            public async Task WhenApiKeyIsInvalid_ThenReturnResponse()
            {
                var result = await _sut.DisconnectAsync(new DisconnectRequest(TestApiKeys.Invalid));

                Assert.That(result.IsSuccessful, Is.False);
                Assert.That(result.ErrorMessage, Is.EqualTo("Not authorized"));
                Assert.That(result.SessionsDisconnecting, Is.EqualTo(0));
            }

            [Test]
            public async Task WhenApiKeyIsValid_AndNotConnectedToVpn_ThenReturnResponse()
            {
                var result = await _sut.DisconnectAsync(new DisconnectRequest(TestApiKeys.Valid));

                Assert.That(result.IsSuccessful, Is.True);
                Assert.That(result.ErrorMessage, Is.Null);
                Assert.That(result.SessionsDisconnecting, Is.EqualTo(0));
            }

            [Test]
            [Ignore("Run ad-hoc. Need to be connected to AirVPN.")]
            public async Task WhenApiKeyIsValid_AndConnectedToVpn_ThenReturnResponse()
            {
                var result = await _sut.DisconnectAsync(new DisconnectRequest(TestApiKeys.Valid));

                Assert.That(result.IsSuccessful, Is.True);
                Assert.That(result.ErrorMessage, Is.Null);
                Assert.That(result.SessionsDisconnecting, Is.GreaterThan(0));
            }
        }

        [TestFixture]
        public class GetStatusInfoAsync : AirVpnClientTests
        {
            [Test]
            public async Task WhenCalled_ThenReturnsResponse()
            {
                var result = await _sut.GetStatusAsync();

                Assert.That(result.IsSuccessful, Is.True);
                Assert.That(result.ErrorMessage, Is.Null);
                Assert.That(result.Planets.Count(), Is.EqualTo(1));
                Assert.That(result.Continents.Count(), Is.GreaterThan(0));
                Assert.That(result.Countries.Count(), Is.GreaterThan(0));
                Assert.That(result.Servers.Count(), Is.GreaterThan(0));
                Assert.That(result.Routes.Count(), Is.GreaterThan(0));
            }
        }
    }
}