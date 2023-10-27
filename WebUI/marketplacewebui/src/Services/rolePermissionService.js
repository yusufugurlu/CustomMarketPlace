import Cookies from "js-cookie";

const { baseUrlRequest } = require("./baseUrlRequest");


async function getCompanyByUserId() {
    const url = "api/RolePermission/GetCompanyByUserId";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

async function getWorkplaces() {
    const url = "api/RolePermission/GetWorkplaces";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

export const rolePermissionService = {
    getCompanyByUserId,
    getWorkplaces,
};  