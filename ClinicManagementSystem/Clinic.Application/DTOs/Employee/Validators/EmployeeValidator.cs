using FluentValidation;

namespace ClinicManagement.Application.DTOs.Employee
{
    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator() 
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is Required !")
                .MinimumLength(3).WithMessage("{PropertyName} must be more than 3 characters .")
                .MaximumLength(100).WithMessage("{PropertyName} must be less than or equal 100 characters .");

            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is Required !")
                .MinimumLength(5).WithMessage("{PropertyName} must be more than 5 characters .")
                .MaximumLength(100).WithMessage("{PropertyName} must be less than or equal 100 characters .");

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is Required !")
                .MinimumLength(8).WithMessage("{PropertyName} must be at least 8 characters long.")
                .MaximumLength(100).WithMessage("{PropertyName} must be less than or equal 100 characters .")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
                .WithMessage("{PropertyName} must contain at least one lowercase letter, one uppercase letter, one digit, and one special character.");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is Required !")
                .MinimumLength(10).WithMessage("{PropertyName} must be more than 5 characters .")
                .MaximumLength(100).WithMessage("{PropertyName} must be less than or equal 100 characters .")
                .EmailAddress();

            RuleFor(x => x.Phone)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is Required !")
                .Length(11).WithMessage("{PropertyName} must be  equal 11 characters .");

            RuleFor(x => x.Photo)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is Required !");

            //RuleFor(x => x.BirthDate)
            //    .NotNull()
            //    .NotEmpty().WithMessage("{PropertyName} is Required !");

            //RuleFor(x => x.Gender)
            //    .NotNull()
            //    .NotEmpty().WithMessage("{PropertyName} is Required !")
            //    .MinimumLength(3).WithMessage("{PropertyName} must be more than 3 characters .")
            //    .MaximumLength(20).WithMessage("{PropertyName} must be less than or equal 20 characters .");
        }
    }
}
