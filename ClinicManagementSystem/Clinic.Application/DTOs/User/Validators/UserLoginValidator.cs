using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.DTOs.User
{
    public class UserLoginValidator : AbstractValidator<UserLoginDTO>
    {
        public UserLoginValidator()
        {
           
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is Required !")
                .MinimumLength(5).WithMessage("{PropertyName} must be more than 5 characters .")
                .MaximumLength(100).WithMessage("{PropertyName} must be less than or equal 100 characters .");

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is Required !")
                .MinimumLength(6).WithMessage("{PropertyName} must be at least 8 characters long.")
                .MaximumLength(100).WithMessage("{PropertyName} must be less than or equal 100 characters .")
                //.Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
                .WithMessage("{PropertyName} must contain at least one lowercase letter, one uppercase letter, one digit, and one special character.");

        }
    }
}