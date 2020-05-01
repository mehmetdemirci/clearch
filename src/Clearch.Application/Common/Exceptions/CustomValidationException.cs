﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clearch.Application.Common.Exceptions
{
    public class CustomValidationException : ClearchCoreException
    {
        public CustomValidationException()
            : base("One or more validation failures have occurred.")
            => this.Failures = new Dictionary<string, string[]>();

        public CustomValidationException(List<ValidationFailure> failures)
            : this()
        {
            var failureGroups = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach (var failureGroup in failureGroups)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.ToArray();

                this.Failures.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}
