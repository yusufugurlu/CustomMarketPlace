import CsLineIcons from 'cs-line-icons/CsLineIcons';
import React, { useEffect } from 'react';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const CustomNotification = ({ description, message, color, icon }) => {

  const ContentIcon = () => (
    <>
      <div className="mb-2">
        <CsLineIcons icon={icon} width="20" height="20" className="cs-icon icon text-primary me-3 align-middle" />
        <span className="align-middle text-primary heading font-heading">{description}</span>
      </div>
      <div className="text-muted mb-2">{message}</div>
    </>
  );

  const ContentColor = () => (
    <>
      <div className="mb-2">
        <span className="align-middle text-primary heading font-heading">{description}</span>
      </div>
      <div className="text-muted mb-2">{message}</div>
    </>
  );

  useEffect(() => {
    const notify = () => toast((color ? <ContentIcon /> : <ContentColor />), { className: { color } });
    notify();
  }, [message]);

  return null;
};


export default CustomNotification;