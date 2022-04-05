using Business.Constants;
using Business.Handlers.Departman.Commands;
using Business.Handlers.PersonelDepartmans.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.PersonelDepartmans.ValidationRules
{
    public class CreatePersonelDepartmentValidator : AbstractValidator<CreatePersonelDepartmenCommand>
    {
        public CreatePersonelDepartmentValidator()
        {
            RuleFor(x => x.PersonelId).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.DepartmanId).NotEmpty().WithMessage(Messages.Required);


        }
    }

    public class UpdatePersonelDepartmentValidator : AbstractValidator<UpdatePersonelDepartmanComand>
    {
        public UpdatePersonelDepartmentValidator()
        {
            RuleFor(x => x.PersonelId).NotEmpty().WithMessage(Messages.Required);
            RuleFor(x => x.DepartmanId).NotEmpty().WithMessage(Messages.Required);
        }
    }
}
