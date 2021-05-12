using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Başarıyla eklendi";
        public static string ProductUpdated = "Ürün Başarıyla güncellendi";
        public static string ProductDeleted = "Ürün Başarıyla silindi";

        public static string userNotfound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Şifre hatalı";

        public static string SuccessfullLogin = "Sisteme giriş başarılı";

        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";

        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";

        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";

        public static string ProductCountOfCategoryError = "Bu kategoride ekleme yapamazsınız";

        public static string ProductNameAlreadyExists = "Bu isimde ürün var";

        public static string CategoryLimitExceded = "Kategori limitini aştınız";

        public static string AuthorizationDenied = "Yetkiniz Yok";
    }
}
