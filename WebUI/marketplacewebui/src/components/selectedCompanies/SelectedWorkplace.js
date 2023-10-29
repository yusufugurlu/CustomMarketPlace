
import { enumHelper } from 'Helper/enum';
import { userService } from 'Services/userService';
import CustomDropdown from 'customCompanents/customDropdown';
import { customSweet } from 'customCompanents/swal';
import { localization } from 'lang/localization';
import React, { useEffect } from 'react';
import { Card, Col, Row } from 'react-bootstrap';
import { useSelector } from 'react-redux';



const SelectedWorkplace = () => {

    const { currentUser, authWorkplace } = useSelector((state) => state.auth);
    const [roleId, setRoleId] = React.useState(false);
    const [workplaceData, setWorkplaceData] = React.useState([]);
    const [selectedWorkplace, setSelectedWorkplace] = React.useState(0);



    useEffect(() => {
        if (currentUser.selectedShop) {
            setSelectedWorkplace(currentUser.selectedShop);
        }
        setRoleId(currentUser.role === enumHelper.roleType.superAdmin);
    }, [currentUser, workplaceData]);

    useEffect(() => {
        const tmpData = [];
        authWorkplace.forEach(element => {
            tmpData.push({
                value: element.id,
                label: element.workplaceName,
            });
        });
        setWorkplaceData(tmpData);

    }, [authWorkplace]);



    const handleChangeWorkplace = (e) => {
        userService.setSelectWorkplaceId(e.value).then((res) => {
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
            <CustomDropdown onChange={handleChangeWorkplace} value={selectedWorkplace} label={localization.strings().shop} options={workplaceData} />
        </>
    );
};

export default SelectedWorkplace;