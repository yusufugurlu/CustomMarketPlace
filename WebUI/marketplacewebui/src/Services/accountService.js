import Cookies from "js-cookie";

const { baseUrlRequest } = require("./baseUrlRequest");


async function signIn(data) {
    const url = "api/Account/Login";
    const result = await baseUrlRequest.postDataNoToken(url, data);
    if(result.success === true){
        Cookies.set('currentUser', result.data.accessToken);
    }
    
    return result;
}

async function logout() {
    const url = "api/Account/Logout";
    const result = await baseUrlRequest.fetchData(url);
    if(result.success === true){
        Cookies.remove('currentUser');
    }
    
    return result;
}


async function changePassword(data) {
    const url = "api/Account/ChangePassword";
    const result = await baseUrlRequest.postDataNoToken(url, data);
    if(result.success === true){
        Cookies.set('currentUser', result.data.accessToken);
    }
    
    return result;
}


async function checkHasEmail(data) {
    const url = "api/Account/CheckHasEmail";
    const result = await baseUrlRequest.postDataNoToken(url, data);
    return result;
}
export const accountService = {
    signIn,
    logout,
    changePassword,
    checkHasEmail,
};  