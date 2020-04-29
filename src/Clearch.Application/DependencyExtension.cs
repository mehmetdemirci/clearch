using System;
using System.Linq;
using System.Reflection;
using Clearch.Application.Abstractions.Commands;
using Clearch.Application.Abstractions.Queries;
using Clearch.Application.Common.Processors;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clearch.Application
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddMediator(assm);
            services.AddHandlers(assm);
            services.AddValidators(assm);

            services.AddScoped<ICommandSender, CommandQueryMediator>();
            services.AddScoped<IQueryProcessor, CommandQueryMediator>();

            return services;
        }

        private static void AddValidators(this IServiceCollection services, Assembly assembly)
        {
            static bool Expression(Type type) => type.Is(typeof(IValidator<>));

            var validators = assembly.GetTypes().Where(type => type.GetInterfaces().Any(Expression));

            foreach (var v in validators)
            {
                var interfaces = v.GetInterfaces().Where(Expression);
                foreach (var i in interfaces)
                {
                    services.AddScoped(i, v);
                }
            }
        }

        private static void AddMediator(this IServiceCollection services, Assembly assm)
        {
            services.AddMediatR(assm)
                    .AddTransient(typeof(IRequestPreProcessor<>), typeof(ValidationRequestPreProcessor<>));
        }

        private static void AddHandlers(this IServiceCollection services, Assembly assembly)
        {
            static bool Expression(Type type) => type.Is(typeof(ICommandHandler<,>)) || 
                                                 type.Is(typeof(ICommandHandler<>)) || 
                                                 type.Is(typeof(IQueryHandler<,>));

            var handlers = assembly.GetTypes().Where(type => type.GetInterfaces().Any(Expression));

            foreach (var h in handlers)
            {
                var handlerInterfaces = h.GetInterfaces().Where(Expression);
                foreach (var hi in handlerInterfaces)
                {
                    services.AddScoped(hi, h);
                }
            }
        }

        private static bool Is(this Type type, Type typeCompare)
        {
            return type.IsGenericType && (type.Name.Equals(typeCompare.Name) || type.GetGenericTypeDefinition() == typeCompare);
        }
    }
}
