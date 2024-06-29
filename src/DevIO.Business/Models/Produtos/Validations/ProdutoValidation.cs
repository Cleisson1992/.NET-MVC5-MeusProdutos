using FluentValidation;

namespace DevIO.Business.Models.Produtos.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisar ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 1000).WithMessage("O campo {PropertyName} precisar ter entre {MinLength} e {MaxLength} caracteres"); 
            
            RuleFor(f => f.Valor)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisar ser maior que {ComparisonValue}"); 
           
        }
    }
}
