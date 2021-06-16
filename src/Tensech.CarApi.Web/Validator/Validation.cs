using FluentValidation;
using Tensech.CarApi.Common;

namespace Tensech.CarApi.Web
{
    public static class Validations
    {
        public static void EnsureValid<TRequest>(TRequest request, IValidator<TRequest> validator)
        {
            var validationError = Errors.ClientSide.ValidationFailure();

            if (request == null)
                throw validationError;

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                foreach (var validationFailure in validationResult.Errors)
                {
                    if (validationError.Info == null)
                        validationError.Info = new System.Collections.Generic.List<ErrorInfo>();
                    validationError.Info?.Add(new ErrorInfo(validationFailure.ErrorCode, validationFailure.ErrorMessage));
                }
                throw validationError;
            }
        }
    }
}
