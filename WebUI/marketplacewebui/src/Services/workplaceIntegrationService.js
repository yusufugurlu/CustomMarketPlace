
const { baseUrlRequest } = require("./baseUrlRequest");


async function getIntegrations() {
    const url = "api/WorkplaceIntegration/GetIntegrations";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

async function createIntegration(dto) {
    const url = "api/WorkplaceIntegration/CreateIntegration";
    const result = await baseUrlRequest.postData(url,dto);
    return result;
}

async function getIntegration(dto) {
    const url = "api/WorkplaceIntegration/GetIntegration";
    const result = await baseUrlRequest.postData(url,dto);
    return result;
}


async function deleteIntegration(dto) {
    const url = "api/WorkplaceIntegration/DeleteIntegration";
    const result = await baseUrlRequest.postData(url,dto);
    return result;
}



export const workplaceIntegrationService = {
    getIntegrations,
    createIntegration,
    getIntegration,
    deleteIntegration,
};  