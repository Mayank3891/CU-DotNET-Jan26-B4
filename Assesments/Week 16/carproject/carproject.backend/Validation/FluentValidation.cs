using CarManagement.Application.DTOs;

using FluentValidation;

public class CreateCarValidator : AbstractValidator<CreateCarDto>
{
    public CreateCarValidator()
    {
        RuleFor(x => x.Brand).NotEmpty();
        RuleFor(x => x.Model).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Year).InclusiveBetween(2000, DateTime.Now.Year);
    }
}