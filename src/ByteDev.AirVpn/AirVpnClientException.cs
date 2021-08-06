using System;
using System.Runtime.Serialization;

namespace ByteDev.AirVpn
{
    /// <summary>
    /// Represents an error occurring in the AirVPN client.
    /// </summary>
    [Serializable]
    public class AirVpnClientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.AirVpnClientException" /> class.
        /// </summary>
        public AirVpnClientException() : base("Error occurred within the AirVPN client.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.AirVpnClientException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AirVpnClientException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.AirVpnClientException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>       
        public AirVpnClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.AirVpnClientException" /> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected AirVpnClientException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}