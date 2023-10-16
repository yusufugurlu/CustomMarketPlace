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


export const accountService = {
    signIn,
};  