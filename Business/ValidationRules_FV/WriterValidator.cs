using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules_FV
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez");
            //hakkında kısmında a karakteri geçmesi zorunluluğu
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Boş Geçilemez").Must(x=>x.Contains('a')).WithMessage("Hakkında bilgisinde 'a' karakteri geçmek zorundadır.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az 3 karakter olmalıdır");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("En fazla 20 karakter olmalıdır");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("En fazla 50 karakter olmalıdır");
            RuleFor(x => x.WriterJobTitle).MaximumLength(20).WithMessage("En fazla 20 karakter olmalıdır");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Mesleği Boş Geçilemez.");
        }
    }
}
