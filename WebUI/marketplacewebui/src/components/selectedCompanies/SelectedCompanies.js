
import { enumHelper } from 'Helper/enum';
import { userService } from 'Services/userService';
import CustomDropdown from 'customCompanents/customDropdown';
import { customSweet } from 'customCompanents/swal';
import { localization } from 'lang/localization';
import React, { useEffect } from 'react';
import { Card, Col, Row } from 'react-bootstrap';
import { useSelector } from 'react-redux';



const SelectedCompanies = () => {

    const { authCompany, currentUser } = useSelector((state) => state.auth);
    const [data, setData] = React.useState([]);
    const [selectedCompany, setSelectedCompany] = React.useState(null);
    const [roleId, setRoleId] = React.useState(false);

    useEffect(() => {
        const tmpData = [];
        authCompany.forEach(element => {
            tmpData.push({
                value: element.id,
                label: element.companyName,
            });
        });
        setData(tmpData);

    }, [authCompany]);

    useEffect(() => {
        if (currentUser.selectedCompany) {
            setSelectedCompany(data.find(option => option.value === currentUser.selectedCompany));
        }
        setRoleId(currentUser.role === enumHelper.roleType.superAdmin);
    }, [currentUser, data]);


    const handleChangeCompany = (e) => {
        userService.setSelectCompany(e.value).then((res) => {
            if (res.status === 200) {
                window.location.reload();
            }
            else {
                customSweet.customSweetAlert(res.message, "error", 2000);
            }
        });


    }

    return (
        <>

            {
                roleId && <Row className='mb-5'>
                    <Col xs="12" lg="6">
                        <CustomDropdown onChange={handleChangeCompany} value={selectedCompany} label={localization.strings().company} placeholder="test" options={data} />
                    </Col>
                </Row>
            }


        </>
    );
};

export default SelectedCompanies;