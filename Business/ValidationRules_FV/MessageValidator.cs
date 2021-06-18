using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules_FV
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Mail Boş Geçilemez");
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konu Boş Geçilemez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj İçeriği Boş Geçilemez");
            RuleFor(x => x.ReceiverMail).Must(x => x.Contains('@')).WithMessage("Geçerli Mail Adresi Giriniz.");
            RuleFor(x => x.MessageSubject).MaximumLength(100).WithMessage("Mesaj en çok 100 karakter olabilir.");



        }
    }
}
