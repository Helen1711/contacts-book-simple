using ContactsBook.models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBook.validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} can not be empty!")
                .Length(3, 20).WithMessage("Length of {PropertyName} must be greater than 2 characters")
                .Must(BeValidName).WithMessage("{PropertyName}  contains invalid characters");
        }


        private bool BeValidName(string name)
        {
            name = name.Replace(" ", "");
            return name.All(Char.IsLetter);
        }
    }
}
