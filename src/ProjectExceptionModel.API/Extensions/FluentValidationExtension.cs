using FluentValidation.AspNetCore;
using FluentValidation.Results;
using ProjectExceptionModel.API.Models;
using System.Globalization;

namespace ProjectExceptionModel.API.Extensions
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services, Type assemblyContainingValidators)
        {
            services.AddFluentValidation(conf =>
            {
                conf.RegisterValidatorsFromAssemblyContaining(assemblyContainingValidators);
                conf.AutomaticValidationEnabled = false;
                conf.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
            });

            return services;
        }

        public static List<MessageResult>? GetErrors(this ValidationResult result)
        {
            return result.Errors?.Select(error => new MessageResult(error.ErrorCode, error.ErrorMessage)).ToList();
        }
    }
}
