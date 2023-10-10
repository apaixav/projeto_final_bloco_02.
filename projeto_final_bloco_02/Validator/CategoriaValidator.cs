using FluentValidation;
using projeto_final_bloco_02.Model;

namespace projeto_final_bloco_02.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {

            RuleFor(p => p.tipo)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

        }

    }
}
