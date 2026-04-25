using BlockedCountry.Domain.Entities;
using FluentValidation;

namespace BlockedCountry.Application.Validation
{
    public class AddBlacklistedCountryValidator : AbstractValidator<BlacklistedCountry>
    {
        public AddBlacklistedCountryValidator()
        {
            RuleFor(B => B.CountryCode).NotEmpty().WithMessage("Country code is required.")
                .Length(2).WithMessage("Country code must be 2 characters long.")
                .Matches("^[A-Z]{2}$").WithMessage("Country code must consist of 2 uppercase letters.");
        }
    }
}
