using Clearch.Application.Common.Exceptions;
using FluentValidation;
using MediatR.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Clearch.Application.Common.Processors
{
    public class ValidationRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationRequestPreProcessor(IEnumerable<IValidator<TRequest>> validators) => this.validators = validators;

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var context = new ValidationContext(request);

            var failures = this.validators
                 .Select(v => v.Validate(context))
                 .SelectMany(result => result.Errors)
                 .Where(f => f != null)
                 .ToList();

            if (failures.Any())
            {
                throw new CustomValidationException(failures);
            }

            return Task.CompletedTask;
        }
    }
}
