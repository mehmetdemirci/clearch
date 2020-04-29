using Clearch.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clearch.Application.Common
{
    public class Result : IResult
    {
        protected Result() { }

        public IEnumerable<string> Messages { get; protected set; } = new List<string>();

        public IDictionary<string, string[]> ValidationMessages { get; protected set; } = new Dictionary<string, string[]>();

        public bool Succeeded { get; protected set; }

        public static IResult Error()
        {
            return new Result { Succeeded = false };
        }

        public static IResult Error(IEnumerable<string> messages)
        {
            return new Result { Succeeded = false, Messages = messages };
        }

        public static IResult Error(string message)
        {
            return new Result { Succeeded = false, Messages = new List<string> { message } };
        }

        public static IResult Invalid(IDictionary<string, string[]> validationMessages)
        {
            return new Result { Succeeded = false, ValidationMessages = validationMessages };
        }

        public static Task<IResult> ErrorAsync()
        {
            return Task.FromResult(Error());
        }

        public static Task<IResult> ErrorAsync(IEnumerable<string> messages)
        {
            return Task.FromResult(Error(messages));
        }

        public static IResult Success()
        {
            return new Result { Succeeded = true };
        }

        public static Task<IResult> SuccessAsync()
        {
            return Task.FromResult(Success());
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        protected Result() { }

        public T Data { get; private set; }

        public static new IResult<T> Error()
        {
            return new Result<T> { Succeeded = false };
        }

        public static new IResult<T> Error(IEnumerable<string> messages)
        {
            return new Result<T> { Succeeded = false, Messages = messages };
        }

        public static new Task<IResult<T>> ErrorAsync()
        {
            return Task.FromResult(Error());
        }

        public new static Task<IResult<T>> ErrorAsync(IEnumerable<string> messages)
        {
            return Task.FromResult(Error(messages));
        }

        public static IResult<TR> Success<TR>(TR data)
        {
            return new Result<TR> { Succeeded = true, Data = data };
        }

        public static Task<IResult<TR>> SuccessAsync<TR>(TR data)
        {
            return Task.FromResult(Success(data));
        }
    }
}
