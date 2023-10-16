import Cookies from "js-cookie";

const { baseUrlRequest } = require("./baseUrlRequest");


async function getMenus() {
    const url = "api/Menu/GetMenus";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

export const menuService = {
    getMenus,
};  