using FluentValidation;
using projeto_final_bloco_02.Model;

namespace projeto_final_bloco_02.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {

            RuleFor(p => p.nome)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(p => p.bula)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(1000);

            RuleFor(p => p.preco)
                .NotEmpty();

            RuleFor(p => p.foto)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(5000);
        }
    }
}
