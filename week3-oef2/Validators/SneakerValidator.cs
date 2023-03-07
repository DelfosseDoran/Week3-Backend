


namespace lab_03_security.Validators;

public class SneakerValidator : AbstractValidator<Sneaker>
{
    public SneakerValidator()
    {
        RuleFor(s => s.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(s => s.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        RuleFor(s => s.Occasions).Must(occs => occs.Count > 0).WithMessage("At least one occasion is required");
        RuleFor(s => s.Brand).NotEmpty().WithMessage("Brand is required");
    }
}
