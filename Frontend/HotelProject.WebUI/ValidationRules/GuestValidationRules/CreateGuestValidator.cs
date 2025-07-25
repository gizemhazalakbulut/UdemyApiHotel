﻿using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator:AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez.");
            RuleFor(x =>x.Name).MinimumLength(3).WithMessage("İsim alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Soyisim alanı en az 2 karakter olmalıdır.");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Şehir alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("İsim alanı en fazla 20 karakter olmalıdır.");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Soyisim alanı en fazla 30 karakter olmalıdır.");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("Şehir alanı en fazla 20 karakter olmalıdır.");
        
        }
    }
}
