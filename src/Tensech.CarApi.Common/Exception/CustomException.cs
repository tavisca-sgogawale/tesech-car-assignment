using System.Net;


namespace Tensech.CarApi.Common
{
    internal class UnExpectedSystemException : BaseApplicationException
    {
        public UnExpectedSystemException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }
    }
    internal class ValidationFailure : BaseApplicationException
    {
        public ValidationFailure(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }

    }
    internal class BadRequestException : BaseApplicationException
    {
        public BadRequestException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }

    }
    public class MissingServiceConfigurationException : BaseApplicationException
    {
        public MissingServiceConfigurationException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }

    }
    public class DataBaseException : BaseApplicationException
    {
        public DataBaseException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }

        public class KeyNotFoundError : BaseApplicationException
        {
            public KeyNotFoundError(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }

        }
    }
    
}