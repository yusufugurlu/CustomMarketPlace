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
            type: "success",
            title: message,
          /*   showConfirmButton: true, */
            timer: time,
            heightAuto: false
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

export const customSweet = {
    customSweetAlert
};