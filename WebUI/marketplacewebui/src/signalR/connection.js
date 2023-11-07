// src/services/signalrService.js

import * as signalR from "@microsoft/signalr";
import { baseUrlRequest } from "Services/baseUrlRequest";
import { BASESERVICE_URL } from "config";

const url = `${BASESERVICE_URL}chatHub`;
console.log(url);

const connection = new signalR.HubConnectionBuilder()
    .withUrl(url, {
        skipNegotiation: true,
        accessTokenFactory: () => baseUrlRequest.getToken(),
        transport: signalR.HttpTransportType.WebSockets,
    }) // Hub URL'nizi buraya ekleyin
    .withAutomaticReconnect()
    .configureLogging(signalR.LogLevel.Trace)
    .build();

const hubConnection=connection;
if(hubConnection){
    console.log(hubConnection);
    connection.on("ReceiveMessage", (data) => {
        console.log(data);
    });
}
connection.start().catch((error) => console.error(error));

export default connection;
