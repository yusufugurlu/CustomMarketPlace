import Cookies from "js-cookie";


function setLanguageCookie(code) {
    Cookies.set('lang', code);
}

function getLanguageCookie() {
    const lang = Cookies.get('lang');
    if (lang) {
        return lang;
    }

    return "tr";
}


export const langHelper = {
    setLanguageCookie,
    getLanguageCookie
};