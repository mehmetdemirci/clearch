using Clearch.Application.Abstractions;
using Clearch.Application.Common;
using Clearch.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Clearch.WebApp.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
            => this.next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code;
            IResult result;

            switch (exception)
            {
                case CustomValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = Result.Invalid(validationException.Failures);
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    result = Result.Error(notFoundException.Message);
                    break;
                case ClearchException clearchException:
                    code = HttpStatusCode.ExpectationFailed;
                    result = Result.Error(clearchException.Message);
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    result = Result.Error(exception.Message);
                    break;

            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var responseText = JsonConvert.SerializeObject(result);
            return context.Response.WriteAsync(responseText);
        }
    }
}
