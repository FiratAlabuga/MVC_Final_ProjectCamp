using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules_FV
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En az 3 karakter olmalıdır");            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En az 3 karakter olmalıdır");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("En fazla 20 karakter olmalıdır");
            RuleFor(x=>x.CategoryDescription).MaximumLength(50).WithMessage("En fazla 50 karakter olmalıdır");
        }
    }
}
