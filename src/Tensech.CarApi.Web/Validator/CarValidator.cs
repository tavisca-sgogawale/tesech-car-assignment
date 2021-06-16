using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensech.CarApi.Common;

namespace Tensech.CarApi.Web
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(y => y.Id)
           .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull()
               .WithErrorCode(FaultCodes.InvalidFieldValue)
               .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Id"))
               .NotEmpty()
               .WithErrorCode(FaultCodes.InvalidFieldValue)
               .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Id"));

            RuleFor(y => y.Name)
           .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull()
               .WithErrorCode(FaultCodes.InvalidFieldValue)
               .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Name"))
               .NotEmpty()
               .WithErrorCode(FaultCodes.InvalidFieldValue)
               .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Name"));


            RuleFor(y => y.Manufacturer)
           .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull()
               .WithErrorCode(FaultCodes.InvalidFieldValue)
               .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Manufacturer"))
               .NotEmpty()
               .WithErrorCode(FaultCodes.InvalidFieldValue)
               .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Manufacturer"));

            RuleFor(y => y.Type)
           .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull()
               .WithErrorCode(FaultCodes.InvalidFieldValue)
               .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Type"))
               .NotEmpty()
               .WithErrorCode(FaultCodes.InvalidFieldValue)
               .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Type"));





            RuleFor(y => y.Type).Custom((type, context) =>
            {
                if (type != null)
                {
                    if ((Services.CarType)Enum.Parse(typeof(Services.CarType), type) == Services.CarType.None)
                        context.AddFailure(new FluentValidation.Results.ValidationFailure("Type", string.Format(FaultMessages.InvalidFieldValue, "Type")));
                }
            });




            RuleFor(y => y.Mileage)
           .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull()
               .WithErrorCode(FaultCodes.InvalidFieldValue)
               .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Mileage"))
               .NotEmpty()
               .GreaterThan(0)
               .WithErrorCode(FaultCodes.InvalidFieldValue)
               .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Mileage"));

            RuleFor(y => y.Price)
           .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull()
              .GreaterThan(0)
              .WithErrorCode(FaultCodes.InvalidFieldValue)
              .WithMessage(string.Format(FaultMessages.InvalidFieldValue, "Price"));

        }




    }
}
