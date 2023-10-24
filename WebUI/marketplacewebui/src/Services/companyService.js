
const { baseUrlRequest } = require("./baseUrlRequest");


async function getActiveCompanies() {
    const url = "api/Company/GetActiveCompanies";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

async function createCompany(dto) {
    const url = "api/Company/CreateCompany";
    const result = await baseUrlRequest.postData(url,dto);
    return result;
}

async function editCompany(dto) {
    const url = "api/Company/EditCompany";
    const result = await baseUrlRequest.postData(url,dto);
    return result;
}


async function deleteCompanies(dto) {
    const url = "api/Company/DeleteCompanies";
    const result = await baseUrlRequest.postData(url,dto);
    return result;
}
export const companyService = {
    getActiveCompanies,
    createCompany,
    editCompany,
    deleteCompanies,
};  