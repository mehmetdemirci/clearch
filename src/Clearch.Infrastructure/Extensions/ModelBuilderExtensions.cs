using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Clearch.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfigurationsFromAssembly(this ModelBuilder modelBuilder)
        {
            static bool Expression(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>);

            var types = Assembly.GetCallingAssembly().GetTypes().Where(type => type.GetInterfaces().Any(Expression)).ToList();

            var configurations = types.Select(Activator.CreateInstance);

            foreach (var configuration in configurations)
            {
                modelBuilder.ApplyConfiguration((dynamic)configuration);
            }
        }
    }
}
