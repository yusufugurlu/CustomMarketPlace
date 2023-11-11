// src/services/signalrService.js

import * as signalR from "@microsoft/signalr";
import { baseUrlRequest } from "Services/baseUrlRequest";
import { BASESERVICE_URL } from "config";

const url = `${BASESERVICE_URL}chatHub`;

const connection = new signalR.HubConnectionBuilder()
    .withUrl(url, {
        skipNegotiation: true,
        accessTokenFactory: () => baseUrlRequest.getToken(),
        transport: signalR.HttpTransportType.WebSockets,
    }) // Hub URL'nizi buraya ekleyin
    .withAutomaticReconnect()
    .build();

connection.start().catch((error) => console.error(error));

export default connection;
