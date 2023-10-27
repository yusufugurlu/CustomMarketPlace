
const { baseUrlRequest } = require("./baseUrlRequest");


async function getActiveWorkPlaces() {
    const url = "api/Workplace/GetActiveWorkPlaces";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

async function createWorkPlace(dto) {
    const url = "api/Workplace/CreateWorkPlace";
    const result = await baseUrlRequest.postData(url,dto);
    return result;
}

async function getWorkPlace(dto) {
    const url = "api/Workplace/GetWorkPlace";
    const result = await baseUrlRequest.postData(url,dto);
    return result;
}


async function deleteWorkPlaces(dto) {
    const url = "api/Workplace/DeleteWorkPlaces";
    const result = await baseUrlRequest.postData(url,dto);
    return result;
}
export const workplaceService = {
    getActiveWorkPlaces,
    createWorkPlace,
    getWorkPlace,
    deleteWorkPlaces,
};  