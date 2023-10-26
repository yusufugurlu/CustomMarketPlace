import React from 'react';
import Form from 'react-bootstrap/Form';

const CustomTextBox = ({ label, value, onChange }) => {
    return (
        <div className="top-label">
            <Form.Control type="text" value={value} onChange={onChange} />
            <Form.Label>{label}</Form.Label>
        </div>
    );
};

export default CustomTextBox;
