using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace ByteDev.AirVpn.UnitTests
{
    [TestFixture]
    public class AirVpnClientExceptionTests
    {
        private const string ExMessage = "some message";

        [Test]
        public void WhenNoArgs_ThenSetMessageToDefault()
        {
            var sut = new AirVpnClientException();

            Assert.That(sut.Message, Is.EqualTo("Error occurred within the AirVPN client."));
        }

        [Test]
        public void WhenMessageSpecified_ThenSetMessage()
        {
            var sut = new AirVpnClientException(ExMessage);

            Assert.That(sut.Message, Is.EqualTo(ExMessage));
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetMessageAndInnerEx()
        {
            var innerException = new Exception();

            var sut = new AirVpnClientException(ExMessage, innerException);

            Assert.That(sut.Message, Is.EqualTo(ExMessage));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
        }

        [Test]
        public void WhenSerialized_ThenDeserializeCorrectly()
        {
            var sut = new AirVpnClientException(ExMessage);

            var formatter = new BinaryFormatter();
            
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, sut);

                stream.Seek(0, 0);

                var result = (AirVpnClientException)formatter.Deserialize(stream);

                Assert.That(result.ToString(), Is.EqualTo(sut.ToString()));
            }
        }
    }
}