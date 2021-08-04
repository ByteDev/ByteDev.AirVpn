using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ByteDev.AirVpn.Contract.Request;
using ByteDev.AirVpn.Contract.Response;
using NUnit.Framework;

namespace ByteDev.AirVpn.UnitTests
{
    [TestFixture]
    public class AirVpnClientTests
    {
        private const string ApiKey = "someApiKey";

        private static AirVpnClient CreateSut(string json)
        {
            return new AirVpnClient(new HttpClient(new FakeResponseHandler(HttpStatusCode.OK, new JsonContent(json))));
        }

        [TestFixture]
        public class GetUserAsync : AirVpnClientTests
        {
            [Test]
            public async Task WhenJsonContainsUnixTime_ThenDeserializesToDateTime()
            {
                const string json = @"{
                    ""user"": {
                        ""expiration_unix"": 1641974376,
                        ""register_unix"": 1641974376,
                        ""last_visit_unix"": 1641974376,
                        ""last_activity_unix"": 1641974376,
                        ""last_attempt_unix"": 1641974376
                    },
                    ""sessions"": [
                        {
                            ""connected_since_unix"": 1641974376 
                        }
                    ]
                }";

                var sut = CreateSut(json);

                var result = await sut.GetUserAsync(new GetUserRequest(ApiKey));

                Assert.That(result.User.ExpirationDateTime, Is.EqualTo(new DateTime(2022, 1, 12, 7, 59, 36)));
                Assert.That(result.User.RegisterDateTime, Is.EqualTo(new DateTime(2022, 1, 12, 7, 59, 36)));
                Assert.That(result.User.LastVisitDateTime, Is.EqualTo(new DateTime(2022, 1, 12, 7, 59, 36)));
                Assert.That(result.User.LastActivityDateTime, Is.EqualTo(new DateTime(2022, 1, 12, 7, 59, 36)));
                Assert.That(result.User.LastAttemptDateTime, Is.EqualTo(new DateTime(2022, 1, 12, 7, 59, 36)));

                Assert.That(result.Sessions.Single().ConnectedSinceDateTime, Is.EqualTo(new DateTime(2022, 1, 12, 7, 59, 36)));
            }
        }

        [TestFixture]
        public class GetStatusAsync : AirVpnClientTests
        {
            [Test]
            public async Task WhenJsonContainsEnum_ThenDeserializesToEnum()
            {
                const string json = @"{
                    ""planets"": [
                        {
                            ""health"": ""ok""
                        }
                    ],
                    ""continents"": [
                        {
                            ""health"": ""warning""
                        }
                    ],
                    ""countries"": [
                        {
                            ""health"": ""error""
                        }
                    ]
                }";

                var sut = CreateSut(json);

                var result = await sut.GetStatusAsync();

                Assert.That(result.Planets.Single().HealthStatus, Is.EqualTo(HealthStatusType.Ok));
                Assert.That(result.Continents.Single().HealthStatus, Is.EqualTo(HealthStatusType.Warning));
                Assert.That(result.Countries.Single().HealthStatus, Is.EqualTo(HealthStatusType.Error));
            }
        }
    }
}