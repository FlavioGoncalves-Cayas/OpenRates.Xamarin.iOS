using System;

namespace OpenRates.Api
{
    public class OpenRatesClientException : Exception
    {
        public OpenRatesClientException()
        {
        }

        public OpenRatesClientException(Exception innerException) : base(string.Empty, innerException)
        {
        }
    }
}