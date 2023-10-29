import React from 'react';
import { Form } from 'react-bootstrap';



const CustomFormCheckbox = ({ value, onChange, labelOn, label, ...rest }) => {
    return (
        <>
            <Form.Label>{label}</Form.Label>
            <Form.Check
                {...rest}
                type="switch"
                id={rest.id}
                checked={value}
                onChange={onChange}
                title={labelOn}
                size="xl"
                label={labelOn}
            />
        </>
    );
};

export default CustomFormCheckbox;