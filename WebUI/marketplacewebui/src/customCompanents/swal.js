import { localization } from 'lang/localization';
import React, { useState } from 'react';
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'

const MySwal = withReactContent(Swal)


function customSweetAlert(message, type, time, footer) {
    let options = {};

    if (time === undefined) {
        time = 2000;
    }

    if (type === "success") {
        options = {
            position: "top-end",
            title: message,
            showConfirmButton: false, 
            timer: time,
            heightAuto: false,
            icon: "success"
        };
    } else if (type === "error") {
        options = {
            type: "error",
            title: localization.strings().error,
            text: message,
            confirmButtonText: localization.strings().ok,
            heightAuto: false
        };
    } else if (type === "warning") {
        options = {
            type: "warning",
            title: localization.strings().warning,
            text: message,
            confirmButtonText: localization.strings().ok,
            heightAuto: false
        };
    } else if (type === "info") {
        options = {
            type: "info",
            text: message,
            confirmButtonText: localization.strings().ok,
            timer: time,
            heightAuto: false
        };
    }
    options.customContainerClass = "whitespacepre";
    MySwal.fire(options);
}

function customAlertQuestion(title, message, returnFunction, returnValue) {
    MySwal.fire({
        title,
        customContainerClass: "whitespacepre",
        text: message,
        type: "warning",
        showCancelButton: true,
        confirmButtonText: localization.strings().yes,
        cancelButtonText: localization.strings().no,
        heightAuto: false,
        reverseButtons: true,
    }).then((result) => {
        if (returnValue === true) {
            returnFunction(result.value, result.dismiss);
        } else if (result.value) {
            returnFunction();
        }
    });
}

export const customSweet = {
    customSweetAlert,
    customAlertQuestion,
};