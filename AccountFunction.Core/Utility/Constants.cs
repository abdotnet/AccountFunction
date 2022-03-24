using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Core.Utility
{
    public class Constants
    {
        public static class ResponseCodes
        {
            public const string Success = "00";
            public const string AlreadyExist = "01";
            public const string Pending = "02";
            public const string NotFound = "03";
            public const string InvalidIssuer = "04";
            public const string TokenExpired = "05";
            public const string TokenValidationFailed = "06";
            public const string InvalidAudience = "07";
            public const string Unauthorized = "08";
            public const string ModelValidation = "09";
            public const string UserNotConfirmed = "10";
            public const string BadRequest = "11";
            public const string InvalidHash = "12";
            public const string WrongUrl = "13";
            public const string NotActive = "14";
            public const string NotOptIn = "15";
            public const string OTPExpired = "16";
            public const string Failed = "99";
            public const string InternalServerError = "98";
            public const string GeneralError = "97";
            // public const string Signature = "96";
        }

        public static class ResponseMessage
        {
            public const string Success = "Success";
            public const string AlreadyExist = "AlreadyExist";
            public const string Pending = "Pending";
            public const string NotFound = "NotFound";
            public const string InvalidIssuer = "InvalidIssuer";
            public const string TokenExpired = "TokenExpired";
            public const string TokenValidationFailed = "TokenValidationFailed";
            public const string InvalidAudience = "InvalidAudience";
            public const string Unauthorized = "Unauthorized";
            public const string ModelValidation = "ModelValidation";
            public const string UserNotConfirmed = "UserNotConfirmed";
            public const string BadRequest = "BadRequest";
            public const string InvalidHash = "InvalidHash";
            public const string WrongUrl = "WrongUrl";
            public const string NotActive = "NotActive";
            public const string NotOptIn = "NotOptIn";
            public const string OTPExpired = "OTPExpired";
            public const string Failed = "Failed";
            public const string InternalServerError = "Internal Server Error";
            public const string GeneralError = "General Error";
        }


    }
}
