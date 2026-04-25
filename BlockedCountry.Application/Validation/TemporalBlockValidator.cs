using BlockedCountry.Application.DTOS;
using FluentValidation;

namespace BlockedCountry.Application.Validation
{
    public class TemporalBlockValidator : AbstractValidator<TemporalBlockDTO>
    {
        public TemporalBlockValidator()
        {
            RuleFor(T => T.CountryCode).NotEmpty().WithMessage("Country code is required.")
                                                .NotEqual("XX").WithMessage("Invalid country code.")
                                                .Length(2).WithMessage("Country code must be 2 characters long.");    
            
            RuleFor(T => T.DurationMinutes).InclusiveBetween(1, 1440).WithMessage("Duration must be between 1 and 1440 minutes.");
        }
    }
}
