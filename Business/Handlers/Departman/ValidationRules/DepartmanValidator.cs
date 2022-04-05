using Business.Constants;
using Business.Handlers.Departman.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.Departman.ValidationRules
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartmanCommand>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(x => x.Kod).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.Ad).NotEmpty().WithMessage(Messages.Required);


        }
    }

    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmanCommand>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(x => x.Kod).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.Ad).NotEmpty().WithMessage(Messages.Required);
        }
    }
}
