using AccountFunction.Core.Utility;
using System;
using System.Net;

namespace AccountFunction.Infrastructure.Exceptions
{
    public class BaseException : Exception
    {
        public string Code { get; set; }
        public HttpStatusCode httpStatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public BaseException(string message) : base(message)
        {

        }

        public BaseException(string code, string message, Exception exception) : base(message, exception)
        {

        }
    }

    public class AlreadyExistException : BaseException
    {
        public AlreadyExistException(string message) : base(message)
        {
            base.Code = Constants.ResponseCodes.AlreadyExist;
            base.httpStatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }

    public class AuthorizationException : BaseException
    {

        public AuthorizationException(string message) : base(message)
        {
            base.Code = Constants.ResponseCodes.Unauthorized;
            base.httpStatusCode = System.Net.HttpStatusCode.Unauthorized;
        }
    }

    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message)
        {
            base.Code = Constants.ResponseCodes.Failed;
            base.httpStatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }

    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message)
        {
            base.Code = Constants.ResponseCodes.NotFound;
            base.httpStatusCode = System.Net.HttpStatusCode.NotFound;
        }
    }
}

