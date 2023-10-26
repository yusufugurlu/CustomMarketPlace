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