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


export const accountService = {
    signIn,
    logout,
};  