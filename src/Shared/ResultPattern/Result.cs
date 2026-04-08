using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Shared.ResultPattern
{
    public class Result
    {
        protected Result()
        {
            Status = ResultStatus.Success;
            Error = default;
        }

        protected Result(Error error)
        {
            Status = ResultStatus.Failure;
            Error = error;
        }

        public ResultStatus Status { get; }
        public Error? Error { get; }

        public static implicit operator Result(Error error) =>
            new(error);

        public static Result Success() =>
            new();

        public static Result Failure(Error error) =>
            new(error);
    }

    public enum ResultStatus
    {
        Success, Failure
    }
}
