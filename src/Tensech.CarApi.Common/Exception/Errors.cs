using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Tensech.CarApi.Common.DataBaseException;

namespace Tensech.CarApi.Common
{
    public static class Errors
    {
        public static class ClientSide
        {
            public static BaseApplicationException UnexpectedSystemException()
            {
                return new UnExpectedSystemException(FaultCodes.UnexpectedSystemException, FaultMessages.UnexpectedSystemException, HttpStatusCode.InternalServerError);
            }
            public static BaseApplicationException ValidationFailure()
            {
                return new ValidationFailure(FaultCodes.ValidationFailure, FaultMessages.ValidationFailure, HttpStatusCode.InternalServerError);
            }

            public static BaseApplicationException InvalidHeader(string value)
            {
                return new ValidationFailure(FaultCodes.InvalidFieldValue, string.Format(FaultMessages.InvalidFieldValue, value), HttpStatusCode.InternalServerError);
            }
            public static BaseApplicationException InvalidFieldValue(string path)
            {
                return new BadRequestException(FaultCodes.InvalidFieldValue, string.Format(FaultMessages.InvalidFieldValue, path), HttpStatusCode.BadRequest);
            }
        }
        public static class ServerSide
        {
            public static BaseApplicationException InternalServerError()
            {
                return new BaseApplicationException(FaultCodes.InternalServerError, FaultMessages.InternalServerError, HttpStatusCode.InternalServerError);
            }
            public static KeyNotFoundError KeyNotFoundException(string key)
            {
                return new KeyNotFoundError(FaultCodes.KeyNotFound, string.Format(FaultMessages.KeyNotFound, key), HttpStatusCode.NotFound);
            }
        }
    }
}
