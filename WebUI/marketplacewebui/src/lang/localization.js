import { langHelper } from "Helper/langHelper";

const labels = {
    en: {
        "en": "en",
        "accessError": "Access Error",
        "ok": "Ok",
        "error": "Error",
        "warning": "Warning",
        "errorOccurredDuringProcessing": "error occurred during processing",
        "dashboard": "Dashboard",
        "yourSessionHasExpired": "Your session has expired.",
        "youAreNotAuthorizedPage": "You are not authorized to the page.",
        "add": "Add",
        "companyDefinition": "Company Definition",
        "companyName": "Company Name",
        "companyShortName": "Company Short Name",
        "search": "Search",
        "edit": "Edit",
        "delete": "Delete",
        "rows": "rows",
        "cancel": "Cancel",
        "save": "Save",
        "shopDefinition": "Shop Definition",
        "company": "Company",
        "shopName": "Shop Name",
        "vkn": "VKN",
        "code": "Code",
        "noRecordFound": "No Record Found",
        "shop": "Shop",
        "noOption": "No Option",
        "login": "Login",
        "forgotPassword": "Forgot Password",
        "yes": "Yes",
        "no": "No",
        "areYouSure": "Are you sure you want to delete this record?",
        "active": "Active",
        "isActive": "Is Active?",
        "selectoption": "Select Option",
        "users": "Users",
        "userDefinitions": "User Definitions",
        "name": "Name",
        "surName": "SurName",
        "email": "Email",
        "password": "Password",
        "confirmPassword": "Confirm Password",
        "roles": "Roles",
        "role": "Role",
        "addUser": "Add User",
        "editUser": "Edit User",
        "gender": "Gender",
        "phone": "Phone",
        "cacheManagement":"Cache Management",
        "cacheAlert":"If you delete these records, your session will end.",
        "definition":"Definition",
    },
    tr: {
        "en": "tr",
        "accessError": "Erişim Hatası",
        "ok": "Tamam",
        "error": "Hata",
        "warning": "Uyarı",
        "errorOccurredDuringProcessing": "işlem sırasında hata oluştu",
        "dashboard": "Anasayfa",
        "yourSessionHasExpired": "Oturumunuz dolmuştur.",
        "youAreNotAuthorizedPage": "Sayfaya yetkiniz bulunmamaktadır.",
        "add": "Ekle",
        "companyDefinition": "Sirket Tanımı",
        "companyName": "Sirket Adı",
        "companyShortName": "Sirket Kısa Adı",
        "search": "Arama",
        "edit": "Düzenle",
        "delete": "Sil",
        "rows": "satır",
        "cancel": "Iptal",
        "save": "Kaydet",
        "shopDefinition": "Mağaza Tanımları",
        "company": "Şirket",
        "shopName": "Mağaza Adı",
        "vkn": "VKN",
        "code": "Kodu",
        "noRecordFound": "Kayıt Bulunamadı",
        "shop": "Mağaza",
        "noOption": "Seçenek bulunamadı",
        "login": "Giriş",
        "forgotPassword": "Şifremi Unuttum",
        "yes": "Evet",
        "no": "Hayır",
        "areYouSure": "Bu kaydı silmek istediğinize emin misiniz?",
        "active": "Aktif",
        "isActive": "Aktif mi?",
        "selectoption": "Seçenek seçin",
        "users": "Kullanıcılar",
        "userDefinitions": "Kullanıcı Tanımları",
        "name": "Adı",
        "surName": "Soyadı",
        "email": "Email",
        "password": "Şifre",
        "confirmPassword": "Şifre Doğrulama",
        "roles": "Yetkiler",
        "role": "Yetki",
        "addUser": "Kullanıcı Ekle",
        "editUser": "Kullanıcıyı Düzenle",
        "gender": "Cinsiyet",
        "phone": "Telefon",
        "cacheManagement":"Ön Bellek Yönetimi",
        "cacheAlert":"Bu kayıtları silerseniz oturumunuz sonlanacaktır.",
        "definition":"Açıklama",
    }
};


function strings(lang = null) {
    const language = langHelper.getLanguageCookie();
    lang = lang === null ? language : lang;

    if (lang === "EN") {
        return labels.en;
    }

    return labels.tr;
}

function getLanguage(lang = null) {
    const language = langHelper.getLanguageCookie();

    lang = lang === null ? language : lang;

    if (lang === "EN") {
        return "en-EN";
    }

    return "tr-TR";
}

export const localization = {
    strings,
    getLanguage
};