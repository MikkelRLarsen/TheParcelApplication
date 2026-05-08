using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.ResultPattern
{
    public class Error
    {
        private Error(
            string code,
            string description,
            ErrorType errorType
        )
        {
            Code = code;
            Description = description;
            ErrorType = errorType;
        }

        public string Code { get; }

        public string Description { get; }

        public ErrorType ErrorType { get; }

        public static Error Failure(string code, string description) =>
            new(code, description, ErrorType.Failure);

        public static Error NotFound(string code, string description) =>
            new(code, description, ErrorType.NotFound);

        public static Error Validation(string code, string description) =>
            new(code, description, ErrorType.Validation);

        public static Error Conflict(string code, string description) =>
            new(code, description, ErrorType.Conflict);

        public static Error AccessUnAuthorized(string code, string description) =>
            new(code, description, ErrorType.AccessUnAuthorized);

        public static Error AccessForbidden(string code, string description) =>
            new(code, description, ErrorType.AccessForbidden);

        public static Error BadRequest(string code, string description) => 
            new(code, description, ErrorType.BadRequest);
    }
    public enum ErrorType
    {
        Failure = 500,
        NotFound = 404,
        Validation = 422,
        Conflict = 409,
        AccessUnAuthorized = 401,
        AccessForbidden = 403,
        BadRequest = 400
    }
}
