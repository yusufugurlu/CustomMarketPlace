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
        "youAreNotAuthorizedPage":"You are not authorized to the page.",
    },
    tr: {
        "en": "tr",
        "accessError": "Erişim Hatası",
        "ok": "Tamam",
        "error": "Hata",
        "warning": "Uyarı",
        "errorOccurredDuringProcessing": "işlem sırasında hata oluştu",
        "dashboard": "Anasayfa",
        "yourSessionHasExpired":"Oturumunuz dolmuştur.",
        "youAreNotAuthorizedPage":"Sayfaya yetkiniz bulunmamaktadır.",
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