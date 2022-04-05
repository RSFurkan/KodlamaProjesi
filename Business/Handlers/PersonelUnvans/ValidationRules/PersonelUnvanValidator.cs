using Business.Handlers.PersonelUnvans.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.PersonelUnvans.ValidationRules
{
    public class CreatePersonelUnvanValidator : AbstractValidator<CreatePersonelUnvanCommand>
    {
        public CreatePersonelUnvanValidator()
        {
           
        }
    }
    public class UpdatePersonelUnvanValidator : AbstractValidator<UpdatePersonelUnvanCommand>
    {
        public UpdatePersonelUnvanValidator()
        {

        }
    }

    
}
