using FluentValidation;

namespace ProjectExceptionModel.API.Models.VMs
{
    public class CriarContaVm
    {
        public string Email { get; set; }
        public string Nome { get; set; }
    }


    public class CriarContaVmValidator : AbstractValidator<CriarContaVm>
    {
        public CriarContaVmValidator()
        {
            When(x => x == null, () =>
            {
                RuleFor(x => x).NotNull();
            }).Otherwise(() =>
            {
                RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("Passou nulo ai po")
                .WithErrorCode("400")
                .NotEmpty()
                .WithMessage("Passou vazio rapá")
                .WithErrorCode("400");


                RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Passou O email vazio po")
                .WithErrorCode("400")
                .NotNull()
                .WithMessage("Passou o email nulo caralho")
                .WithErrorCode("400");
            });
        }
    }
}
