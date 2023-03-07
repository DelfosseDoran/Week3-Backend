using System;

namespace week3.Validators
{
    public class BrandRepositoryValidator: AbstractValidator<Brand>
    {
        public BrandRepositoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
        }
    }
}
