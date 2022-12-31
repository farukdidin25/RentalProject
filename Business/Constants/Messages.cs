using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarNotAdded = "Araba Eklendi";
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string CarListed = " Arabalar Listelendi";
        public static string CarNotUpdated = "Arabalar Güncellenemedi";
        public static string CarNotDeleted = "Araba Silinmedi";
        public static string MaintenanceTime = "Kullanım Dışı";
        public static string CarNameInvalid = "Araba İsmi Geçersiz";

        public static string ColorNotAdded = "Renk Eklenemedi";
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorListed = " Renkler Listelendi";
        public static string ColorNotUpdated = "Renkler Güncellenemedi";
        public static string ColorNotDeleted = "Renk Silinmedi";

        public static string BrandNotAdded = "Marka Eklenemedi";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandListed = " Markaler Listelendi";
        public static string BrandNotUpdated = "Markaler Güncellenemedi";
        public static string BrandNotDeleted = "Marka Silinmedi";

        public static string CustomerNotAdded = "Müşteri Eklenemedi";
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerListed = " Müşteriler Listelendi";
        public static string CustomerNotUpdated = "Müşteriler Güncellenemedi";
        public static string CustomerNotDeleted = "Müşteri Silinmedi";

        public static string UserNotAdded = "Kullanıcı Eklenemedi";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserListed = " Kullanıcılar Listelendi";
        public static string UserNotUpdated = "Kullanıcılar Güncellenemedi";
        public static string UserNotDeleted = "Kullanıcı Silinmedi";

        public static string RentalNotAdded = "Kiralama Eklenemedi";
        public static string RentalAdded = "Kiralama Eklendi";
        public static string RentalDeleted = "Kiralama Silindi";
        public static string RentalUpdated = "Kiralama Güncellendi";
        public static string RentalListed = " Kiralamaları Listelendi";
        public static string RentalNotUpdated = "Kiralamaları Güncellenemedi";
        public static string RentalNotDeleted = "Kiralama Silinmedi";

        public static string ImageNotAdded = "Fotoğraf Eklenemedi";
        public static string ImageAdded = "Fotoğraf Eklendi";
        public static string ImageDeleted = "Fotoğraf Silindi";
        public static string ImageUpdated = "Fotoğraf Güncellendi";
        public static string ImageListed = " Fotoğraf Listelendi";
        public static string ImageNotUpdated = "Fotoğrafı Güncellenemedi";
        public static string ImageNotDeleted = "Fotoğraf Silinmedi";
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi";

        public static string UserRegistered = "Kullanıcı Kayıt Oldu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatası";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string AccessTokenCreated = "Erişim Belirteci Oluşturuldu";
    }
}
