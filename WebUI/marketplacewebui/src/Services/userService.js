import Cookies from "js-cookie";

const { baseUrlRequest } = require("./baseUrlRequest");


async function getUserInfo() {
    const url = "api/User/GetUserInfo";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}


async function changeLanguage(code) {
    const dto = {
        Language: code
    }
    const url = "api/User/ChangeLanguge";
    const result = await baseUrlRequest.postData(url, dto);
    if(result.success === true){
        Cookies.set('currentUser', result.data.accessToken);
    }
    return result;
}

export const userService = {
    getUserInfo,
    changeLanguage,
};  