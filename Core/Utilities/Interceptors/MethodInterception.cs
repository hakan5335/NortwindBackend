using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)//invocation çalıştırmak istediğimiz metod oluyor
        {
            var isSuccess = true;
            OnBefore(invocation);//Metodun başında çalıştır. genelde bunu kullanırız
            try
            {
                invocation.Proceed();//metodu çalıstırır
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e); //Hata verdiğinde çalıştırılacak. geneldew bunu kullanırız
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);//Başarılı oldugunda
                }
            }
            OnAfter(invocation);//Metoddan sonra çalıssın
        }
    }
}
