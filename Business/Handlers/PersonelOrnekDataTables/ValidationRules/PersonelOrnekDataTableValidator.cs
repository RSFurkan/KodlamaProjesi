using Business.Constants;
using Business.Handlers.PersonelOrnekDataTables.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.PersonelOrnekDataTables.ValidationRules
{
    public class CreatePersonelOrnekDataTableValidator : AbstractValidator<CreatePersonelOrnekDataTableCommand>
    {
        public CreatePersonelOrnekDataTableValidator()
        {
            RuleFor(x => x.PersonelId).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.IseGirisTarihi).NotEmpty().WithMessage(Messages.Required); 
        }
    }

    public class UpdatePersonelOrnekDataTableValidator : AbstractValidator<UpdatePersonelOrnekDataTableCommand>
    {
        public UpdatePersonelOrnekDataTableValidator()
        {
            RuleFor(x => x.PersonelId).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.IseGirisTarihi).NotEmpty().WithMessage(Messages.Required);
        }
    }
}
