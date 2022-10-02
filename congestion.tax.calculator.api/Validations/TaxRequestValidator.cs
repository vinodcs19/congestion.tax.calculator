using System;
using FluentValidation;

namespace congestion.tax.calculator.api.Validations
{
    public class TaxRequestValidator : AbstractValidator<TollTaxRequest>
    {
        public TaxRequestValidator()
        {
            RuleFor(f => f.DateTimes).NotNull().NotEmpty().WithMessage("Date Time should not be null or empty.");
            RuleFor(f => f.VehicleType).NotNull().NotEmpty().WithMessage("VehicleType should not be null or empty.");
        }
    }
}
