using FluentValidation;

namespace Api.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}