import React, { useEffect } from 'react';
import DataTable from 'customCompanents/DataTables/dataTable';
import { useHistory } from 'react-router-dom';
import { localization } from 'lang/localization';
import { Button, Form, Modal } from 'react-bootstrap';
import { customSweet } from 'customCompanents/swal';
import { workplaceIntegrationService } from 'Services/workplaceIntegrationService';
import { enumService } from 'Services/enumService';
import CustomDropdown from 'customCompanents/customDropdown';



const integration = () => {
    const history = useHistory();
    const [data, setData] = React.useState([]);
    const [isDataLoading, setIsDataLoading] = React.useState(false);
    const [isOpenAddModal, setIsOpenAddModal] = React.useState(false);
    const [apiSecret, setApiSecret] = React.useState("");
    const [apiKey, setApiKey] = React.useState("");
    const [idForApi, setIdForApi] = React.useState("");
    const [workplaceIntegrationId, setWorkplaceIntegrationId] = React.useState(0);
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


    useEffect(() => {
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
        setApiKey("");
    }



    const handleSave = (e) => {
        const dto = {
            "id": workplaceIntegrationId,
            "apiSecret": apiSecret,
            "idForApi": idForApi,
            "apiKey": apiKey,
            "integrationType": 0,
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
                isActiveEditButton
                handlerEditButton={handlerEdit}
                isLoading={isDataLoading}
                isActiveBuyButton
                handleBuyButton={() => {
                    history.push("/");
                }}
            />

            <Modal className=" modal-right fade" show={isOpenAddModal} onHide={handlerClear}>
                <Modal.Header>
                    <Modal.Title>{workplaceIntegrationId === 0 ? localization.strings().add : localization.strings().edit}</Modal.Title>
                </Modal.Header>
                <Modal.Body>

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

export default integration;
