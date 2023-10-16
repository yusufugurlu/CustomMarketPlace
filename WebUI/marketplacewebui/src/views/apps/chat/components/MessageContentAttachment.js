import React, { useState } from 'react';
import { Spinner } from 'react-bootstrap';

const MessageContentAttachment = ({ attachments, time }) => {
  const [photoIndex, setPhotoIndex] = useState(0);
  const [isOpen, setIsOpen] = useState(false);

  const openLightbox = (index) => {
    setPhotoIndex(index);
    setIsOpen(true);
  };

  if (attachments && attachments.length > 0) {
    return (
      <>
        {attachments.map((attachment, aIndex) => {
          return (
            <div key={`m.attachment.${aIndex}`} className="d-inline-block sh-11 ms-2 position-relative pb-4 bg-primary rounded-md">
              <div className="lightbox h-100 attachment cursor-pointer" onClick={() => openLightbox(aIndex)}>
                <img src={attachment} className="h-100 rounded-md-top" alt={attachment} />
              </div>
              <span className="position-absolute text-extra-small text-white opacity-75 b-2 s-2 time">{time}</span>
            </div>
          );
        })}
      </>
    );
  }
  return <></>;
};
export default MessageContentAttachment;
