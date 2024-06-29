using FluentValidation;

namespace DevIO.Business.Models.Fornecedores.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(f => f.Logradouro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisar ter entre {MinLength} e {MaxLength} caracteres"); 
            
            RuleFor(f => f.Bairro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisar ter entre {MinLength} e {MaxLength} caracteres"); 
            
            RuleFor(f => f.Cep)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(8).WithMessage("O campo {PropertyName} precisar ter {MaxLength} caracteres"); 
            
            RuleFor(f => f.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisar ter entre {MinLength} e {MaxLength} caracteres"); 
            
            RuleFor(f => f.Estado)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisar ter entre {MinLength} e {MaxLength} caracteres"); 
            
            RuleFor(f => f.Numero)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisar ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
