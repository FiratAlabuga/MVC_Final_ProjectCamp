using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules_FV
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En az 3 karakter olmalıdır");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter olmalıdır");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("En fazla 20 karakter olmalıdır");
            RuleFor(x => x.Message).MaximumLength(100).WithMessage("En fazla 100 karakter olmalıdır");
        }
    }
}
