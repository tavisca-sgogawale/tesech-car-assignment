using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Tensech.CarApi.Common;
using Tensech.CarApi.Web.Models;

namespace Tensech.CarApi.Web
{
    public class ModifyCarRequestValidator : AbstractValidator<ModifyCarRequest>
    {
        public ModifyCarRequestValidator()
        {
            RuleFor(x => x.Car)
               .NotNull()
               .WithErrorCode(FaultCodes.InvalidFieldValue)
               .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Car"));

            RuleFor(y => y.Car).SetValidator(new CarValidator());
        }
    }
}
