using FluentValidation;


namespace CleanArchitectureWebApi.Application.Blogs.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .Length(1, 20)
                .WithMessage("Name must not exceed 20 characters");

            RuleFor(v => v.Description)
                .NotEmpty()
                .WithMessage("Description is required");

            RuleFor(v => v.Author)
                .NotEmpty()
                .WithMessage("Author is required")
                .Length(5, int.MaxValue)
                .WithMessage("Author at least 5 characters");
        }
    }
}
