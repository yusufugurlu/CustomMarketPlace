import React, { useEffect } from 'react';
import { Form } from 'react-bootstrap';
import Select from 'react-select';

const CustomDropdown = ({ options, value, onChange, placeholder, label }) => {

    useEffect(() => {
        console.log(value);
    }, [value]);


    const handleOnChange = (e) => {
        onChange(e);
    }

    return (

        <>
            <Form.Label className="d-block">{label}</Form.Label>
            <Select
                classNamePrefix="react-select"
                options={options}
                defaultOptions={options}
                value={value}
                onChange={handleOnChange}
                placeholder={placeholder}
            />
        </>

    );
};

export default CustomDropdown;
