
const { baseUrlRequest } = require("./baseUrlRequest");



async function updateSystemParameter(dto) {
    const url = "api/SystemParameter/UpdateSystemParameter";
    const result = await baseUrlRequest.postData(url,dto);
    return result;
}

async function getSystemParameters() {
    const url = "api/SystemParameter/GetSystemParameters";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

export const systemParameterService = {
    updateSystemParameter,
    getSystemParameters,
};  