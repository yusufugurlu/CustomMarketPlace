
const { baseUrlRequest } = require("./baseUrlRequest");



async function getAllKeys() {
    const url = "api/Common/GetAllKeys";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

async function deleteDatas(data) {
    const url = "api/Common/DeleteDatas";
    const result = await baseUrlRequest.postData(url, data);
    return result;
}

export const commonService = {
    getAllKeys,
    deleteDatas,
};  