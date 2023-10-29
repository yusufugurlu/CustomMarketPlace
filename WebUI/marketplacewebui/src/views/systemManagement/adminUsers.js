import React, { useEffect } from 'react';
import DataTable from 'customCompanents/DataTables/dataTable';
import { localization } from 'lang/localization';
import { companyService } from 'Services/companyService';
import { Button, Form, Modal } from 'react-bootstrap';
import { customSweet } from 'customCompanents/swal';
import CustomTextBox from 'customCompanents/customTextBox';
import { rolePermissionService } from 'Services/rolePermissionService';
import { useDispatch } from 'react-redux';
import { setAuthCompany } from 'auth/authSlice';
import { enumService } from 'Services/enumService';
import CustomDropdown from 'customCompanents/customDropdown';
import { userService } from 'Services/userService';
import CustomButton from 'customCompanents/customButton';

const adminUsers = () => {

    const dispatch = useDispatch();

    const [data, setData] = React.useState([]);
    const [isDataLoading, setIsDataLoading] = React.useState(false);
    const [isOpenAddModal, setIsOpenAddModal] = React.useState(false);
    const [name, setName] = React.useState("");
    const [surName, setSurName] = React.useState("");
    const [userId, setUserId] = React.useState(0);
    const [isActive, setIsActive] = React.useState(false);
    const [roles, setRoles] = React.useState([]);
    const [selectedRoles, setSelectedRoles] = React.useState(null);
    const [genders, setGenders] = React.useState([]);
    const [selectedGender, setSelectedGender] = React.useState(null);
    const [email, setEmail] = React.useState("");
    const [phone, setPhone] = React.useState("");

    const getRoles = () => {
        enumService.getRoles().then((res) => {
            if (res.status === 200) {
                const tmpData = [];
                res.data.forEach(element => {
                    tmpData.push({
                        value: element.id,
                        label: element.name,
                    });
                });
                setRoles(tmpData);
            }
        });
    }

    const getGenders = () => {
        enumService.getGenders().then((res) => {
            if (res.status === 200) {
                const tmpData = [];
                res.data.forEach(element => {
                    tmpData.push({
                        value: element.id,
                        label: element.name,
                    });
                });
                setGenders(tmpData);
            }
        });
    }


    const getAuthCompanies = () => {
        rolePermissionService.getCompanyByUserId().then((res) => {
            if (res.status === 200) {
                dispatch(setAuthCompany(res.data));
            }
        });
    }

    const getUsersByCompanyId = () => {
        setIsDataLoading(true);
        userService.getUsersByCompanyId().then((result) => {
            if (result.data.length > 0) {
                setData(result.data);
            }
            else {
                setData([]);
            }
            setIsDataLoading(false);
        });
    }

    useEffect(() => {
        getUsersByCompanyId();
        getRoles();
        getGenders();
    }, []);



    const handlerEdit = (selectedRowIds) => {
        userService.getUser({ id: selectedRowIds.id }).then((result) => {
            if (result.status === 200) {
                setUserId(selectedRowIds.id);
                setName(result.data.name);
                setSurName(result.data.surName);
                setEmail(result.data.email);
                setPhone(result.data.phone);
                setSelectedGender(result.data.gender);
                setSelectedRoles(result.data.roleId)
                setIsOpenAddModal(true);
            }
            else {
                customSweet.customSweetAlert(result.message, result.status, 2000);
            }
        });

    }


    const handleResetPassword = (e) => {
        console.log(e);
    }

    const columns = [
        {
            Header: '',
            id: 'action',
            headerClassName: 'empty w-10',
            Cell: ({ row }) => {
                const { checked, onChange } = row.getToggleRowSelectedProps();
                return <Form.Check className="form-check float-end mt-1" type="checkbox" checked={checked} onChange={onChange} />;
            },
        },
        {
            Header: localization.strings().name,
            accessor: 'name',
            sortable: true,
            headerClassName: 'text-muted text-small text-uppercase w-30',
            Cell: ({ cell }) => {
                return (
                    <a
                        className="list-item-heading body"
                        href="#!"
                        onClick={(e) => {
                            e.preventDefault();
                            handlerEdit(cell.row.original);
                        }}
                    >
                        {cell.value}
                    </a>
                );
            },
        },
        { Header: localization.strings().surName, accessor: 'surName', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
        { Header: localization.strings().email, accessor: 'email', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
        { Header: localization.strings().phone, accessor: 'phone', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
        { Header: localization.strings().role, accessor: 'role', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
        { Header: localization.strings().gender, accessor: 'gender', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
        {
            Header: 'İşlemler',
            id: 'passwordRecovery',
            headerClassName: 'empty w-10',
            Cell: ({ cell }) => {
                return <CustomButton className="form-check float-end mt-1" text="Sıfırla" onClick={() => { handleResetPassword(cell.row.original); }} />;
            },
        },
    ];




    const handlerAdd = () => {
        setIsOpenAddModal(true);
    }

    const handlerDelete = (selectedRowIds) => {

        customSweet.customAlertQuestion(
            localization.strings().delete,
            localization.strings().areYouSure,
            () => {
                const dtos = [];
                selectedRowIds.forEach((x) => {
                    dtos.push(x.id);
                });

                const dto = {
                    userIds: dtos
                };

                setIsDataLoading(true);
                userService.deleteUsers(dto).then((result) => {
                    if (result.status === 200) {
                        customSweet.customSweetAlert(result.message, "success", 2000);
                        getUsersByCompanyId();
                        getAuthCompanies();
                    }
                    else {
                        customSweet.customSweetAlert(result.message, "error", 2000);
                    }
                    setIsDataLoading(false);
                });

            }
        );
    }

    const handlerClear = () => {
        setName("");
        setSurName("");
        setEmail("");
        setPhone("");
        setSelectedGender(0);
        setSelectedRoles(0);
        setIsOpenAddModal(false);
        setIsActive(false);
        setUserId(0);
    }

    const handleSave = (e) => {

        if (userId > 0) {
            const dto = {
                "id": userId,
                "name": name,
                "surName": surName,
                "eMail": email,
                "phone": phone,
                "roleId": selectedRoles,
                "gender": selectedGender,
            }

            console.log(dto);
            setIsDataLoading(true);
            userService.updateUser(dto).then((result) => {
                if (result.status === 200) {
                    customSweet.customSweetAlert(result.message, "success", 2000);
                    getUsersByCompanyId();
                    getAuthCompanies();
                }
                else {
                    customSweet.customSweetAlert(result.message, result.status, 2000);
                }
                setIsOpenAddModal(false);
                handlerClear();
            });
        }
        else {
            const dto = {
                "name": name,
                "surName": surName,
                "eMail": email,
                "phone": phone,
                "roleId": selectedRoles,
                "gender": selectedGender,
            }

            console.log(dto);
            setIsDataLoading(true);
            userService.createUser(dto).then((result) => {
                if (result.status === 200) {
                    customSweet.customSweetAlert(result.message, "success", 2000);
                    getUsersByCompanyId();
                    getAuthCompanies();
                }
                else {
                    customSweet.customSweetAlert(result.message, result.status, 2000);
                }
                setIsOpenAddModal(false);
                handlerClear();
            });
        }

    }

    const handleChangeRole = (e) => {
        setSelectedRoles(e.value);
    }

    const handleChangeGender = (e) => {
        setSelectedGender(e.value);
    }

    return (
        <>

            <DataTable
                columnList={columns}
                dataList={data}
                title={localization.strings().userDefinitions}
                isActiveAddButton
                handlerAddButton={handlerAdd}
                isActiveDeleteButton
                handlerDeleteButton={handlerDelete}
                isActiveEditButton
                handlerEditButton={handlerEdit}
                isLoading={isDataLoading}
            />

            <Modal className=" modal-right fade" show={isOpenAddModal} onHide={handlerClear}>
                <Modal.Header>
                    <Modal.Title>{userId === 0 ? localization.strings().add : localization.strings().edit}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div className="mb-3">
                        <CustomTextBox label={localization.strings().name} value={name} onChange={(e) => setName(e.target.value)} />
                    </div>
                    <div className="mb-3">
                        <CustomTextBox label={localization.strings().surName} value={surName} onChange={(e) => setSurName(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <CustomTextBox label={localization.strings().email} value={email} onChange={(e) => setEmail(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <CustomTextBox label={localization.strings().phone} value={phone} onChange={(e) => setPhone(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <CustomDropdown onChange={handleChangeGender} value={selectedGender} label={localization.strings().gender} options={genders} />
                    </div>
                    <div className="mb-3">
                        <CustomDropdown onChange={handleChangeRole} value={selectedRoles} label={localization.strings().roles} options={roles} />
                    </div>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="outline-primary" onClick={handlerClear}>
                        {localization.strings().cancel}
                    </Button>
                    <Button variant="primary" onClick={handleSave}>
                        {localization.strings().save}
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
};

export default adminUsers;
