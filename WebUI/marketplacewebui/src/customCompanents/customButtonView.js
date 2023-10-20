import CsLineIcons from 'cs-line-icons/CsLineIcons';
import React, { useState } from 'react';

function CustomButtonView({ onClick }) {
  return (
    <a href="#/!" onClick={onClick}>
      <CsLineIcons icon="logout" className="me-2" size={17} /> <span className="align-middle">Logout</span>
    </a>
  );
}

export default CustomButtonView;
