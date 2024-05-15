using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";
    public CustomerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(NotEmptyMessage)
            .MinimumLength(3).WithMessage("Minimum 3 karakter olmalıdır.");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(NotEmptyMessage)
            .EmailAddress().WithMessage("Email adresi doğru formatta olmalıdır");
        
        RuleFor(x => x.Age)
            .NotEmpty().WithMessage(NotEmptyMessage)
            .InclusiveBetween(18,60).WithMessage("Age alanı 18 ile 60 arasında olmalıdır.");

        RuleFor(x => x.BirthDay)
            .NotEmpty().WithMessage(NotEmptyMessage)
            .Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaşınız 18 yaşından büyük olmalıdır.");

        RuleFor(x => x.Gender).IsInEnum().WithMessage("{PropertyName} alanı Erkek=1, Kadın=2 değerini almalıdır.");

        RuleForEach(x=>x.Addresses).SetValidator(new AddressValidator());

    }
}
