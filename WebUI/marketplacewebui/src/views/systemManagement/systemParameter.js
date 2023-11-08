import React, { useEffect } from 'react';
import DataTable from 'customCompanents/DataTables/dataTable';
import { workplaceService } from 'Services/workplaceService';
import { localization } from 'lang/localization';
import { Button, Form, Modal } from 'react-bootstrap';
import { customSweet } from 'customCompanents/swal';
import { useDispatch } from 'react-redux';
import { systemParameterService } from 'Services/systemParameterService';
import CsLineIcons from 'cs-line-icons/CsLineIcons';



const systemParameter = () => {
  const dispatch = useDispatch();
  const [data, setData] = React.useState([]);
  const [isDataLoading, setIsDataLoading] = React.useState(false);
  const [isOpenAddModal, setIsOpenAddModal] = React.useState(false);
  const [smtpUserName, setSmtpUserName] = React.useState("");
  const [smtpHost, setSmtpHost] = React.useState("");
  const [smtpPassword, setSmtpPassword] = React.useState("");
  const [isActiveAdd, setIsActiveAdd] = React.useState(false);

  const [smtpPort, setSmtpPort] = React.useState("0");
  const [maximumWorkplaceNumber, setMaximumWorkplaceNumber] = React.useState("0");
  const [maximumUserNumber, setMaximumUserNumber] = React.useState("0");
  const [isLock, setIsLock] = React.useState(false);

  const getSystemParameters = () => {

    setIsDataLoading(true);
    systemParameterService.getSystemParameters().then((result) => {
      if (result.data.length > 0) {
        setData(result.data);
        setIsActiveAdd(false);
      }
      else {
        setData([]);
        setIsActiveAdd(true);
      }

      setIsDataLoading(false);
    });
  }

  useEffect(() => {
    getSystemParameters();
  }, []);


  const handlerEdit = (selectedRowIds) => {
    setSmtpUserName(selectedRowIds.smtpUserName);
    setSmtpPassword(selectedRowIds.smtpPassword);
    setSmtpHost(selectedRowIds.smtpHost);
    setSmtpPort(selectedRowIds.smtpPort);
    setIsOpenAddModal(true);
    setMaximumWorkplaceNumber(selectedRowIds.maximumWorkplaceNumber);
    setMaximumUserNumber(selectedRowIds.maximumUserNumber);

  }

  const columns = [
    { Header: localization.strings().smtpHost, accessor: 'smtpHost', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
    { Header: localization.strings().smtpUserName, accessor: 'smtpUserName', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
    { Header: localization.strings().smtpPort, accessor: 'smtpPort', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
    { Header: localization.strings().maximumWorkplaceNumber, accessor: 'maximumWorkplaceNumber', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
    { Header: localization.strings().maximumUserNumber, accessor: 'maximumUserNumber', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
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
    setSmtpUserName("");
    setSmtpPassword("");
    setIsOpenAddModal(false);
    setSmtpHost("");
    setSmtpPort("");
    setMaximumWorkplaceNumber("0");
    setMaximumUserNumber("0");
  }


  const handleSave = (e) => {

    const dto = {
      "smtpUserName": smtpUserName,
      "smtpPassword": smtpPassword,
      "smtpHost": smtpHost,
      "smtpPort": smtpPort,
      "maximumWorkplaceNumber": maximumWorkplaceNumber,
      "maximumUserNumber": maximumUserNumber,
    }

    setIsDataLoading(true);
    systemParameterService.updateSystemParameter(dto).then((result) => {
      if (result.status === 200) {
        customSweet.customSweetAlert(result.message, "success", 2000);
        getSystemParameters();
      }
      else {
        customSweet.customSweetAlert(result.message, "error", 2000);
      }
      setIsOpenAddModal(false);
      setIsDataLoading(false);
    });

  }


  const handlerAddButton = (e) => {
    handlerClear();
    setIsOpenAddModal(true);
  }

  
  return (
    <>

      <DataTable
        columnList={columns}
        dataList={data}
        title={localization.strings().systemParameters}
        isActiveEditButton
        isActiveAddButton={isActiveAdd}
        handlerAddButton={handlerAddButton}
        handlerEditButton={handlerEdit}
        isLoading={isDataLoading}
      />

      <Modal className=" modal-right fade" show={isOpenAddModal} onHide={handlerClear}>
        <Modal.Header>
          <Modal.Title>{isActiveAdd === true ? localization.strings().add : localization.strings().edit}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="mb-3">
            <Form.Label>{localization.strings().smtpHost}</Form.Label>
            <Form.Control type="text" value={smtpHost} onChange={(e) => setSmtpHost(e.target.value)} />
          </div>

          <div className="mb-3">
            <Form.Label>{localization.strings().smtpUserName}</Form.Label>
            <Form.Control type="text" value={smtpUserName} onChange={(e) => setSmtpUserName(e.target.value)} />
          </div>

          <div className="mb-3 filled">
            <CsLineIcons icon={isLock ? "lock-off" : "lock-on"} onClick={() => { setIsLock(!isLock);}} />
            <Form.Control type={isLock ? "text" : "password"} value={smtpPassword} onChange={(e) => setSmtpPassword(e.target.value)} placeholder={localization.strings().smtpPassword} />
          </div>

          <div className="mb-3">
            <Form.Label>{localization.strings().smtpPort}</Form.Label>
            <Form.Control type="text" value={smtpPort} onChange={(e) => setSmtpPort(e.target.value)} />
          </div>

          <div className="mb-3">
            <Form.Label>{localization.strings().maximumWorkplaceNumber}</Form.Label>
            <Form.Control type="text" value={maximumWorkplaceNumber} onChange={(e) => setMaximumWorkplaceNumber(e.target.value)} />
          </div>
          <div className="mb-3">
            <Form.Label>{localization.strings().maximumWorkplaceNumber}</Form.Label>
            <Form.Control type="text" value={maximumUserNumber} onChange={(e) => setMaximumUserNumber(e.target.value)} />
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

export default systemParameter;
