import Cookies from "js-cookie";

const { baseUrlRequest } = require("./baseUrlRequest");


async function getRoles() {
    const url = "api/Enum/GetRoles";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

export const enumService = {
    getRoles,
};  