using FluentValidation;
using LanguageExt.Common;
using ProjectExceptionModel.API.Extensions;
using ProjectExceptionModel.API.Models;
using ProjectExceptionModel.API.Models.VMs;
using ProjectExceptionModel.API.Repositories;
using System.Text.Json;

namespace ProjectExceptionModel.API.Services
{
    public interface ICrirarContaService
    {
        Task<Result<MessageResult>> CreatAccount(CriarContaVm vm);
    }

    public class CrirarContaService : ICrirarContaService
    {
        private readonly CriarContaVmValidator _validator;
        private readonly ISqlDataAccess _sql;

        public CrirarContaService(CriarContaVmValidator validator, ISqlDataAccess sql)
        {
            _validator = validator;
            _sql = sql;
        }

        public async Task<Result<MessageResult>> CreatAccount(CriarContaVm vm)
        {
            try
            {
                var val = await _validator.ValidateAsync(vm);

                if (!val.IsValid)
                {
                    var validationException = new ValidationException(JsonSerializer.Serialize(val.GetErrors()));
                    return new Result<MessageResult>(validationException);
                }

                if (vm.Nome == "renato" && vm.Email == "renato")
                {
                    var requestSql = await _sql.LoadData<string, dynamic>("select * from Cartao", new { });
                }

                return new MessageResult("200", "Deu certo se pá");
            }
            catch (Exception ex)
            {
                return new Result<MessageResult>(ex);
            }
        }
    }
}
