using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensech.CarApi.Common;
using Tensech.CarApi.Web.Models;

namespace Tensech.CarApi.Web
{
    public class AddCarRequestValidator : AbstractValidator<AddCarRequest>
    {
        public AddCarRequestValidator()
        {
            RuleFor(x => x.Car)
               .NotNull()
               .WithErrorCode(FaultCodes.InvalidFieldValue)
               .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Car"));

            RuleFor(y => y.Car).SetValidator(new CarValidator());
        }
    }
}
