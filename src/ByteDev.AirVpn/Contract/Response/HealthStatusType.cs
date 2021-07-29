namespace ByteDev.AirVpn.Contract.Response
{
    /// <summary>
    /// Health status type.
    /// </summary>
    public enum HealthStatusType
    {
        /// <summary>
        /// The health status could not be determined.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Health is fine.
        /// </summary>
        Ok = 1,

        /// <summary>
        /// Health problems. For example a low packet loss.
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Major health problems. For example a high packet loss or maintenance.
        /// </summary>
        Error = 3
    }
}