using ProjectExceptionModel.API.Extensions;
using ProjectExceptionModel.API.Models.VMs;
using ProjectExceptionModel.API.Services;

namespace ProjectExceptionModel.API.Endpoints
{
    public static class CriarConta
    {
        public static void CriarContaEndpoint(this WebApplication app)
        {
            app.MapGet("criarconta", CriarContaProcessor);
        }

        private static async Task<IResult> CriarContaProcessor(string email, string nome, ICrirarContaService service)
        {

            try
            {
                CriarContaVm vm = new()
                {
                    Email = email,
                    Nome = nome,
                };

                var result = await service.CreatAccount(vm);

                return result.ToReturn(c => c);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
