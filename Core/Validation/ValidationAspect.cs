using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Validation
{
    public class ValidationAspect 
    {
     
        public ValidationAspect( )
        { 
            throw new ArgumentException("validation error");
        
        }
        protected   void OnBefore( )
        { 
            throw new ArgumentException("validation error");
        }
    }
}
