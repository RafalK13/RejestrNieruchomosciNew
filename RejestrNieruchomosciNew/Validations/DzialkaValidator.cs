﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Validations
{
    public class DzialkaValidator : AbstractValidator<Dzialka>
    {

        public DzialkaValidator()
        {
            RuleFor(p => p.Numer).Matches(@"^\d*/*\d+$")
           //RuleFor(p => p.Numer).Matches(@"^\d+$")
               .WithMessage("Tylko cyfry/cyfry");

            RuleFor(n => n.Pow).Must(DoubleConverters.toDouble4).WithMessage("Max.4 cyfry po przec.");

            RuleFor(p => p.Kwakt).Matches(@"(^$)|(^GD\dG/{1}\d+/{1}\d{1}$)")
                .WithMessage("GD-G/----/-");

            RuleFor(p => p.Kwzrob).Matches(@"(^$)|(^GD\dG/{1}\d+/{1}\d{1}$)")
                .WithMessage("GD-G/----/-");

        }
    }
}
