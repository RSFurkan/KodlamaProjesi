using Business.Handlers.Departman.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.Departman.ValidationRules
{
    public class DepartmanValidator : AbstractValidator<CreateDepartmanCommand>
    {
        public DepartmanValidator()
        {

        }
    }
}
