const { baseUrlRequest } = require("./baseUrlRequest");



async function ceatePasswordRecovery(dto) {
    const url = "api/UserPasswordRecovery/CreatePasswordRecovery";
    const result = await baseUrlRequest.postData(url, dto);
    return result;
}

async function checkGuid(guid) {
    const url = `api/Account/CheckGuid/${guid}`;
    const result = await baseUrlRequest.fetchDataNoToken(url);
    return result;
}
export const userPasswordRecoveryService = {
    ceatePasswordRecovery,
    checkGuid,
};  