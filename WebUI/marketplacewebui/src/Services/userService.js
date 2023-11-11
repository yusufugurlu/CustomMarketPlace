import Cookies from "js-cookie";

const { baseUrlRequest } = require("./baseUrlRequest");


async function getUserInfo() {
    const url = "api/User/GetUserInfo";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}


async function changeLanguage(code) {
    const dto = {
        Language: code
    }
    const url = "api/User/ChangeLanguge";
    const result = await baseUrlRequest.postData(url, dto);
    if (result.success === true) {
        Cookies.set('currentUser', result.data.accessToken);
    }
    return result;
}

async function setSelectCompany(companyId) {
    const url = `api/Common/SetSelectCompany/${companyId}`;
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

async function setSelectWorkplaceId(workplaceId) {
    const url = `api/Common/SetSelectWorkplaceId/${workplaceId}`;
    const result = await baseUrlRequest.fetchData(url);
    return result;
}


async function createUser(dto) {
    const url = "api/User/CreateUser";
    const result = await baseUrlRequest.postData(url, dto);
    return result;
}

async function getUsersByCompanyId() {
    const url = `api/User/GetUsersByCompanyId`;
    const result = await baseUrlRequest.fetchData(url);
    return result;
}

async function getUser(dto) {
    const url = "api/User/GetUser";
    const result = await baseUrlRequest.postData(url, dto);
    return result;
}

async function updateUser(dto) {
    const url = "api/User/UpdateUser";
    const result = await baseUrlRequest.postData(url, dto);
    return result;
}

async function deleteUsers(dto) {
    const url = "api/User/DeleteUsers";
    const result = await baseUrlRequest.postData(url, dto);
    return result;
}

async function createUserForNormalRole(dto) {
    const url = "api/User/CreateUserForNormalRole";
    const result = await baseUrlRequest.postData(url, dto);
    return result;
}

export const userService = {
    getUserInfo,
    changeLanguage,
    setSelectCompany,
    setSelectWorkplaceId,
    createUser,
    getUsersByCompanyId,
    getUser,
    updateUser,
    deleteUsers,
    createUserForNormalRole,
};  