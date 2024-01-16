using FluentValidation;

namespace CleanArchitectureWebApi.Application.Common
{
    public abstract class ApplicationValidator<T> : AbstractValidator<T>
    {
    }
}
