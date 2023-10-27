import { localization } from 'lang/localization';
import React, { useEffect } from 'react';
import { Form } from 'react-bootstrap';
import Select from 'react-select';

const CustomDropdown = ({ options, value, onChange, placeholder, label }) => {

    const [selectedData, setSelectedData] = React.useState(0);

    useEffect(() => {
        setSelectedData(options.find(option => option.value === value));
    }, [value, options]);


    const handleOnChange = (e) => {
        onChange(e);
    }

    return (

        <>
            <Form.Label className="d-block">{label}</Form.Label>
            <Select
                classNamePrefix="react-select"
                styles={{ width: '100%' }}
                options={options}
                defaultOptions={options}
                value={selectedData}
                onChange={handleOnChange}
                placeholder={placeholder}
                noOptionsMessage={() => localization.strings().noOption}
            />
        </>

    );
};

export default CustomDropdown;
