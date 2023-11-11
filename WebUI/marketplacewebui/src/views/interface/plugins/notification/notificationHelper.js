import React, { useEffect } from 'react';
import CsLineIcons from "cs-line-icons/CsLineIcons";
import { localization } from "lang/localization";
import { routes } from "routes";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';


const ContentIcon = ({ description, message, color, icon }) => (
    <>
        <div className="mb-2">
            <CsLineIcons icon={icon} width="20" height="20" className="cs-icon icon text-primary me-3 align-middle" />
            <span className="align-middle text-primary heading font-heading">{description}</span>
        </div>
        <div className="text-muted mb-2">{message}</div>
    </>
);

const ContentColor = ({ description, message }) => (
    <>
        <div className="mb-2">
            <span className="align-middle text-primary heading font-heading">{description}</span>
        </div>
        <div className="text-muted mb-2">{message}</div>
    </>
);

const callToast = (description, message, color, icon) => {
    const notify = () => toast((icon ? <ContentIcon
        description={description}
        message={message}
        color={color}
        icon={icon} />
        :
        <ContentColor
            description={description}
            message={message} />), { className: { color } });
    notify();
}

export const notificationHelper = {
    callToast,
};