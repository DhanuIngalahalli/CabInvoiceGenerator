using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class CabInvoiceException : Exception
    {
        /// <summary>
        /// enum for exception type
        /// </summary>
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID
        }
        ExceptionType type;
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}