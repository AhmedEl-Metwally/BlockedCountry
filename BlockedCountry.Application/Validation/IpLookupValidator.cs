using FluentValidation;
using System.Net;

namespace BlockedCountry.Application.Validation
{
    public class IpLookupValidator : AbstractValidator<string>
    {
        public IpLookupValidator()
        {
            RuleFor(IP => IP)
                .Must(BeAValidIp).WithMessage("Invalid IP address format.");
        }

        private bool BeAValidIp(string ip)
        {
            if (string.IsNullOrEmpty(ip))
                return true;

            return IPAddress.TryParse(ip, out _);
        }
    }
}
