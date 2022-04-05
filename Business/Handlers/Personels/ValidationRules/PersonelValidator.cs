using Business.Constants;
using Business.Handlers.Personels.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Handlers.Personels.ValidationRules
{
    public class CreatePersonelValidator : AbstractValidator<CreatePersonelCommand>
    {
        public CreatePersonelValidator()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.SoyAd).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.SicilNumarasi).MaximumLength(4).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.Cinsiyet).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.CepTelefonu).MaximumLength(11).NotEmpty().WithMessage(Messages.Required); 
        }
    }

    public class UpdatePersonelValidator : AbstractValidator<UpdatePersonelCommand>
    {
        public UpdatePersonelValidator()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.SoyAd).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.SicilNumarasi).MaximumLength(4).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.Cinsiyet).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.CepTelefonu).MaximumLength(11).NotEmpty().WithMessage(Messages.Required);
        }
    }
}
