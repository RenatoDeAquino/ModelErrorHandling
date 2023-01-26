using FluentValidation;
using LanguageExt.Common;
using ProjectExceptionModel.API.Models;
using System.Text.Json;

namespace ProjectExceptionModel.API.Extensions;

public static class EndpointExtensions
{
    public static IResult ToReturn<TResult, TContract>(this Result<TResult> result, Func<TResult, TContract> mapper)
    {
        return result.Match<IResult>(b =>
        {
            var response = mapper(b);
            return Results.Ok(response);
        }, exception =>
        {
            if (exception is ValidationException validationException)
            {
                var ajuda = JsonSerializer.Deserialize<List<MessageResult>>(validationException.Message);
                return Results.BadRequest(ajuda);
            }

            return Results.Problem(detail: "Erro interno");
        });
    }
}
