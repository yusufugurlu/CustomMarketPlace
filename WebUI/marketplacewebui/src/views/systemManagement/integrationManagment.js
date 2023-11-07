import React, { useEffect } from 'react';
import DataTable from 'customCompanents/DataTables/dataTable';
import { workplaceService } from 'Services/workplaceService';
import { localization } from 'lang/localization';
import { Button, Form, Modal } from 'react-bootstrap';
import { customSweet } from 'customCompanents/swal';
import { workplaceIntegrationService } from 'Services/workplaceIntegrationService';
import { enumService } from 'Services/enumService';
import CustomDropdown from 'customCompanents/customDropdown';



const integrationManagment = () => {
    const [data, setData] = React.useState([]);
    const [isDataLoading, setIsDataLoading] = React.useState(false);
    const [isOpenAddModal, setIsOpenAddModal] = React.useState(false);
    const [apiSecret, setApiSecret] = React.useState("");
    const [apiKey, setApiKey] = React.useState("");
    const [idForApi, setIdForApi] = React.useState("");
    const [workplaceIntegrationId, setWorkplaceIntegrationId] = React.useState(0);
    const [integrationTypes, setIntegrationTypes] = React.useState([]);
    const [selectedIntegrationType, setSelectedIntegrationType] = React.useState(null);

    const getIntegrations = () => {

        setIsDataLoading(true);
        workplaceIntegrationService.getIntegrations().then((result) => {
            if (result.data.length > 0) {
                setData(result.data);
            }
            else {
                setData([]);
            }

            setIsDataLoading(false);
        });
    }

    const getIntegrationType = () => {
        enumService.getIntegrationType().then((res) => {
            if (res.status === 200) {
                const tmpData = [];
                res.data.forEach(element => {
                    tmpData.push({
                        value: element.id,
                        label: element.name,
                    });
                });
                setIntegrationTypes(tmpData);
            }
        });
    }

    useEffect(() => {
        getIntegrationType();
        getIntegrations();
    }, []);



    const handlerEdit = (selectedRowIds) => {
        workplaceIntegrationService.getIntegration({ id: selectedRowIds.id }).then((result) => {
            if (result.status === 200) {
                setWorkplaceIntegrationId(selectedRowIds.id);
                setApiSecret(result.data.apiSecret);
                setIdForApi(result.data.idForApi);
                setApiKey(result.data.apiKey);
                setIsOpenAddModal(true);
                setSelectedIntegrationType(result.data.integrationType);
            }
            else {
                customSweet.customSweetAlert(result.message, result.status, 2000);
            }
        });

    }

    const columns = [
        {
            Header: localization.strings().integrationType,
            accessor: 'integrationTypeName',
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
        { Header: "API KEY", accessor: 'apiKey', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
        { Header: "API Secret", accessor: 'apiSecret', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
        { Header: "ID For API", accessor: 'idForApi', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
        {
            Header: '',
            id: 'action',
            headerClassName: 'empty w-10',
            Cell: ({ row }) => {
                const { checked, onChange } = row.getToggleRowSelectedProps();
                return <Form.Check className="form-check float-end mt-1" type="checkbox" checked={checked} onChange={onChange} />;
            },
        },
    ];



    const handlerClear = () => {
        setApiSecret("");
        setIdForApi("");
        setIsOpenAddModal(false);
        setWorkplaceIntegrationId(0);
        setSelectedIntegrationType(0);
        setApiKey("");
    }

    const handlerAdd = () => {
        handlerClear();
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
                    workplaceIntegrationIds: dtos
                };

                setIsDataLoading(true);
                workplaceIntegrationService.deleteIntegration(dto).then((result) => {
                    if (result.status === 200) {
                        getIntegrations();
                        customSweet.customSweetAlert(result.message, "success", 2000);
                    }
                    else {
                        customSweet.customSweetAlert(result.message, "error", 2000);
                    }
                    setIsDataLoading(false);
                });

            }
        );
    }


    const handleSave = (e) => {
        const dto = {
            "id": workplaceIntegrationId,
            "apiSecret": apiSecret,
            "idForApi": idForApi,
            "apiKey": apiKey,
            "integrationType":selectedIntegrationType,
        }

        setIsDataLoading(true);
        workplaceIntegrationService.createIntegration(dto).then((result) => {
            if (result.status === 200) {
                customSweet.customSweetAlert(result.message, "success", 2000);
                getIntegrations();
            }
            else {
                customSweet.customSweetAlert(result.message, "error", 2000);
            }
            setIsDataLoading(false);
            setIsOpenAddModal(false);
        });

    }

    const handleChangeIntegrationType = (e) => {
        setSelectedIntegrationType(e.value);
    }

    return (
        <>

            <DataTable
                columnList={columns}
                dataList={data}
                title={localization.strings().integrationManagment}
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
                    <Modal.Title>{workplaceIntegrationId === 0 ? localization.strings().add : localization.strings().edit}</Modal.Title>
                </Modal.Header>
                <Modal.Body>

                    <div className="mb-3">
                        <CustomDropdown onChange={handleChangeIntegrationType} value={selectedIntegrationType} label={localization.strings().integrationType} options={integrationTypes} />
                    </div>

                    <div className="mb-3">
                        <Form.Label>API KEY</Form.Label>
                        <Form.Control type="text" value={apiKey} onChange={(e) => setApiKey(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <Form.Label>API SECRET</Form.Label>
                        <Form.Control type="text" value={apiSecret} onChange={(e) => setApiSecret(e.target.value)} />
                    </div>
                    
                    <div className="mb-3">
                        <Form.Label>ID FOR API</Form.Label>
                        <Form.Control type="text" value={idForApi} onChange={(e) => setIdForApi(e.target.value)} />
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

export default integrationManagment;
