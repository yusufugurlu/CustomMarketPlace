const { baseUrlRequest } = require("./baseUrlRequest");



async function getNotificationForTopMenuByUserId(dto) {
    const url = "api/Notification/GetNotificationForTopMenuByUserId";
    const result = await baseUrlRequest.fetchData(url);
    return result;
}


export const notificationService = {
    getNotificationForTopMenuByUserId,
};  