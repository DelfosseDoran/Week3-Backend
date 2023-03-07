namespace week3.Validators;
public class CarRepositoryValidator : AbstractValidator<Car>
{
    public CarRepositoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Brand).NotEmpty();

    }
}
