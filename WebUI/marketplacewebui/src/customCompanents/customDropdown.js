import { localization } from 'lang/localization';
import React, { useEffect } from 'react';
import { Form } from 'react-bootstrap';
import Select from 'react-select';

const CustomDropdown = ({ options, value, onChange, label }) => {

    const [selectedData, setSelectedData] = React.useState(0);
    const [data, setData] = React.useState([]);

    useEffect(() => {
        setSelectedData(options.find(option => option.value === value));
    }, [value, options]);

    useEffect(() => {
        if (options) {
            if (options.length > 0) {
                setData(options);
            }
            else {
                setData([]);
            }
        }
        else {
            setData([]);
        }
    }, [options]);

    const handleOnChange = (e) => {
        onChange(e);
    }

    return (

        <>
            <Form.Label className="d-block">{label}</Form.Label>
            <Select
                classNamePrefix="react-select"
                styles={{ width: '100%' }}
                options={data}
                defaultOptions={data}
                value={selectedData}
                onChange={handleOnChange}
                placeholder={localization.strings().selectoption}
                noOptionsMessage={() => localization.strings().noOption}
            />
        </>

    );
};

export default CustomDropdown;
