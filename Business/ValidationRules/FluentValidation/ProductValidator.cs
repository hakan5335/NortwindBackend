using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.ProductName).MinimumLength(2);
            RuleFor(x => x.UnitPrice).NotEmpty();
            RuleFor(x => x.UnitPrice).GreaterThan(0);//0 dan büyük olmalı
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(10).When(x => x.CategoryID == 1);//categoryid 1 oldugunda 10dan yükeşit olmalı
            RuleFor(x => x.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");//kendi özel validasyonumuzu yazdık
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
