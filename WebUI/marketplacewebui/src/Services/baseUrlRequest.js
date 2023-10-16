import { BASESERVICE_URL } from "config";
import { localization } from "lang/localization";
import Cookies from "js-cookie";
import axios from "axios";
import { customSweet } from "customCompanents/swal";

export function handleError(error) {
    const errorDto = {
        data: {},
        errors: [],
        message: localization.strings().errorOccurredDuringProcessing,
        statusCode: 0,
        success: false
    };

    if (error.response === undefined) {
        return errorDto;
    }

    const statusCode = error.response.status;
    if (error.response) {
        if (statusCode === 401) {

            errorDto.data = error.response.data.data;
            errorDto.errors = error.response.data.errors;
            errorDto.message = error.response.data.message;
            errorDto.statusCode = statusCode;
            errorDto.success = false;
            const currentUser = Cookies.get("currentUser");
            if (currentUser) {
                Cookies.remove("currentUser");
            }

         
        }

        customSweet.customSweetAlert(localization.strings().yourSessionHasExpired, 'error', 2000);
    }

    return errorDto;
}

const getToken = () => {
    const token = Cookies.get('currentUser');
    let jwt = '';
    if (token) {
        jwt = token;
    }
    return jwt;
}

const activeLogin = () => {
    const token = Cookies.get('currentUser');
    if (token) {
        return true;
    }
    return false;
}

const getConfig = () => {
    const token = getToken();
    let jwt = '';
    if (token) {
        jwt = token;
    }

    const config = {

        headers: {
            Authorization: `Bearer ${jwt}`,
        },
    };

    return config;
}

async function fetchData(url) {
    url = `${BASESERVICE_URL}${url}`;
    try {
        const response = await axios.get(url, getConfig());
        return response.data;
    }
    catch (err) {
        return handleError(err);
    }
}

async function fetchDataNoToken(url) {
    url = `${BASESERVICE_URL}${url}`;
    try {
        const response = await axios.get(url);
        return response.data;
    }
    catch (err) {
        return handleError(err);
    }
}

async function postData(url, data) {
    url = `${BASESERVICE_URL}${url}`;
    try {
        const response = await axios.post(url, data, getConfig());
        return response.data;
    }
    catch (err) {
        console.log(err);
        return handleError(err);
    }
}

async function postDataNoToken(url, data) {
    url = `${BASESERVICE_URL}${url}`;
    try {
        const response = await axios.post(url, data, getConfig());
        return response.data;
    }
    catch (err) {
        return handleError(err);
    }
}



export const baseUrlRequest = {
    fetchData,
    fetchDataNoToken,
    postData,
    postDataNoToken,
    handleError,
    getToken,
    activeLogin,
}