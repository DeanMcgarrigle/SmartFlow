using FluentValidation;
using SmartFlow.DTO.Meraki;

namespace SmartFlow.Validation
{
    public class FloorConfigDtoValidator : AbstractValidator<FloorConfigDto>
    {
        public FloorConfigDtoValidator()
        {
            RuleFor(x => x.X).NotEmpty().WithMessage("Please enter an X value");
            RuleFor(x => x.Y).NotEmpty().WithMessage("Please enter an Y value");
        }
    }

    public class AccessPointConfigDtoValidator : AbstractValidator<AccessPointConfigDto>
    {
        public AccessPointConfigDtoValidator()
        {
            RuleFor(x => x.DisplayName).NotEmpty().WithMessage("Please enter a Display Name");
            RuleFor(x => x.X).NotEmpty().WithMessage("Please enter an X value");
            RuleFor(x => x.Y).NotEmpty().WithMessage("Please enter an Y value");
        }
    }
}