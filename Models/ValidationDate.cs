using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
namespace Prover.Models
{
    public class ValidationDate : AbstractValidator<Cadastro>
    {
        public ValidationDate()
        {           
            RuleFor(v => v.DateOfBirth)
                .NotNull().WithMessage("A data de nascimento não pode ser nula")                
                .LessThan(DateTime.Now).WithMessage("A data de nascimento não pode ser maior que a data atual");

            RuleFor(v => v.MaleOrFemale).Must(MaleorFemale).WithMessage("o campo Sexo precisa ser M ou F")
                .NotNull().NotEmpty().WithMessage("O campo sexo não pode ser nulo ou vazio"); 
        }

        private bool MaleorFemale(char maleOrFemale)
        {
            return maleOrFemale == 'M' || maleOrFemale == 'F';
        }
    }
}
