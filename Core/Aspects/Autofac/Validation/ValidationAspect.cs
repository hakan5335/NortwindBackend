using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//Atribute oldugundan Type olmak zorunda
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)//MethodInterception ovverride ettik onu çalıstırdık. Yani metod girdiğinde ilk bu çalısacak invocation metod oluyor.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Refleksion:calısma anında bir seyleri çalısmamızı sağlıyor. ProductValidatorun bir new ini olustur demek
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//ProductValidatorun basetypei  generic tipini bul(Product oluyor)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
