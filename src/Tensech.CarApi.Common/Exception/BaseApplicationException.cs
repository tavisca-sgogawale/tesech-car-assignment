using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tensech.CarApi.Common
{
    public class BaseApplicationException: Exception
    {
        public BaseApplicationException(string message, string code)
        {
            ErrorCode = code;
            ErrorMessage = message;
            Info = new List<ErrorInfo>();
        }
        public BaseApplicationException(string errorCode, string errorMessage, HttpStatusCode httpStatusCode, List<ErrorInfo> info = null)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            HttpStatusCode = httpStatusCode;
            Info = info;
        }
        public string ErrorCode { get; }
        public string ErrorMessage { get; }
        public HttpStatusCode HttpStatusCode { get; }
        public List<ErrorInfo> Info { get; set; }
    }
}
