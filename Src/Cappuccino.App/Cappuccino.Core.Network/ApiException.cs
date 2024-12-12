using System;
using Cappuccino.Core.Network.Models;
using Cappuccino.Core.Network.Models.Messages;

namespace Cappuccino.Core.Network {

    [Serializable]
    public class ApiException : Exception 
    {
        public int ErrorCode { get; }
        public string? ErrorMessage { get; }


        public ApiException(string message, Exception innerException) : base(message, innerException) {}

        public ApiException(string message) : base(message)
        {
            System.Diagnostics.Debug.WriteLine("[ex] api exception: " + message);
        }
        public ApiException() {}

        public ApiException(ErrorResponse.Error error) 
        { 
            ErrorCode = error.ErrorCode;
            ErrorMessage = error.ErrorMsg;

            System.Diagnostics.Debug.WriteLine("[ex] errorcode=" + error.ErrorCode.ToString() 
                + ", errormsg=" + error.ErrorMsg);
        }
    }
}