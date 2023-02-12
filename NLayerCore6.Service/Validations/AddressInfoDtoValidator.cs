using FluentValidation;
using NLayerCore6.Core.DTOs;

namespace NLayerCore6.Service.Validations
{
    public class AddressInfoDtoValidator : AbstractValidator<AddressInfoDto>
    {
        public AddressInfoDtoValidator()
        {
            //RuleFor(x => x.CityName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            //RuleFor(x => x.CityCode).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            //RuleFor(x => x.DistrictName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            //RuleFor(x => x.ZipCode).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
