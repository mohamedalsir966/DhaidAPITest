using FluentValidation;
using Inspector.Service.InspectorFeaturs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Service.Validators
{
    public class CreateInspectorServiceCommandValidator : AbstractValidator<CreateInspectorServiceCommand>
    {
        public CreateInspectorServiceCommandValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
        }
    }
}
