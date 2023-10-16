import React, { useState } from 'react';
import { Spinner, Tooltip, OverlayTrigger, Row, Col } from 'react-bootstrap';
import CsLineIcons from 'cs-line-icons/CsLineIcons';
import Clamp from 'components/clamp';

const EmailCorrespondenceAttachments = ({ id, attachments }) => {
  const [photoIndex, setPhotoIndex] = useState(0);
  const [isOpen, setIsOpen] = useState(false);

  const openLightbox = (index) => {
    setPhotoIndex(index);
    setIsOpen(true);
  };
  return (
    <div className="mt-4 d-flex flex-row flex-wrap">
      {attachments.map((attach, attachIndex) => {
        const { title, size, source } = attach;
        return (
          <div key={`mail.attachment.${id}.a${attachIndex}`} className="sw-30 me-2 mb-2">
            <Row className="g-0 rounded-sm sh-8 border">
              <Col xs="auto">
                <a
                  href={`#${id}.${source}`}
                  className="lightbox"
                  onClick={(event) => {
                    event.preventDefault();
                    openLightbox(attachIndex);
                  }}
                >
                  <img src={source} className="card-img card-img-horizontal rounded-sm-start sw-10" alt={title} />
                </a>
              </Col>
              <Col className="rounded-sm-end d-flex flex-column justify-content-center px-3">
                <div className="d-flex justify-content-between">
                  <Clamp tag="p" className="mb-0" clamp="1">
                    {title}
                  </Clamp>
                  <OverlayTrigger delay={{ show: 1000, hide: 0 }} placement="top" overlay={<Tooltip id="tooltip-top">Download</Tooltip>}>
                    <a
                      href="#download"
                      onClick={(event) => {
                        event.preventDefault();
                      }}
                    >
                      <CsLineIcons icon="download" size="17" />
                    </a>
                  </OverlayTrigger>
                </div>
                <div className="text-small text-primary">{size}</div>
              </Col>
            </Row>
          </div>
        );
      })}
    </div>
  );
};

export default EmailCorrespondenceAttachments;
