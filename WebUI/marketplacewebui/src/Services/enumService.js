import Cookies from "js-cookie";

const { baseUrlRequest } = require("./baseUrlRequest");


async function getRoles() {
    const url = "api/Enum/GetRoles";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

async function getGenders() {
    const url = "api/Enum/GetGenders";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

async function getIntegrationType() {
    const url = "api/Enum/GetIntegrationType";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

async function getRolesForNormalRole() {
    const url = "api/Enum/GetRolesForNormalRole";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

export const enumService = {
    getRoles,
    getGenders,
    getIntegrationType,
    getRolesForNormalRole,
};  