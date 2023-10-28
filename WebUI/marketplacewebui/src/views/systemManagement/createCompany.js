import React, { useEffect } from 'react';
import DataTable from 'customCompanents/DataTables/dataTable';
import { localization } from 'lang/localization';
import { companyService } from 'Services/companyService';
import { Button, Form, Modal } from 'react-bootstrap';
import { customSweet } from 'customCompanents/swal';



const createCompany = () => {

  const [data, setData] = React.useState([]);
  const [isDataLoading, setIsDataLoading] = React.useState(false);
  const [isOpenAddModal, setIsOpenAddModal] = React.useState(false);
  const [companyName, setCompanyName] = React.useState("");
  const [companShortName, setCompanyShortName] = React.useState("");
  const [companyId, setCompanyId] = React.useState(0);

  const getCompanies = () => {
    setIsDataLoading(true);
    companyService.getActiveCompanies().then((result) => {
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
    getCompanies();
  }, []);



  const handlerEdit = (selectedRowIds) => {
    companyService.editCompany({ id: selectedRowIds.id }).then((result) => {
      if (result.status === 200) {
        setCompanyId(selectedRowIds.id);
        setCompanyName(result.data.name);
        setCompanyShortName(result.data.shortName);
        setIsOpenAddModal(true);
      }
      else {
        customSweet.customSweetAlert(result.message, result.status, 2000);
      }
    });

  }

  const columns = [
    {
      Header: localization.strings().companyName,
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
    { Header: localization.strings().companyShortName, accessor: 'shortName', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
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




  const handlerAdd = () => {
    setIsOpenAddModal(true);
  }

  const handlerDelete = (selectedRowIds) => {
    const dtos = [];
    selectedRowIds.forEach((x) => {
      dtos.push(x.id);
    });

    const dto = {
      companyIds: dtos
    };

    companyService.deleteCompanies(dto).then((result) => {
      if (result.status === 200) {
        customSweet.customSweetAlert(result.message, "success", 2000);
        getCompanies();
      }
      else {
        customSweet.customSweetAlert(result.message, "error", 2000);
      }
    });
  }


  const handleSave = (e) => {
    const dto = {
      "id": companyId,
      "name": companyName,
      "shortName": companShortName
    }

    setIsDataLoading(true);
    companyService.createCompany(dto).then((result) => {
      if (result.status === 200) {
        customSweet.customSweetAlert(result.message, "success", 2000);
        getCompanies();
      }
      else {
        customSweet.customSweetAlert(result.message, result.status, 2000);
      }
      setIsOpenAddModal(false);
    });

  }

  const handlerClear = () => {
    setCompanyName("");
    setCompanyShortName("");
    setIsOpenAddModal(false);
    setCompanyId(0);
  }
  return (
    <>

      <DataTable
        columnList={columns}
        dataList={data}
        title={localization.strings().companyDefinition}
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
          <Modal.Title>{localization.strings().add}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="mb-3">
            <Form.Label>{localization.strings().companyName}</Form.Label>
            <Form.Control type="text" value={companyName} onChange={(e) => setCompanyName(e.target.value)} />
          </div>
          <div className="mb-3">
            <Form.Label>{localization.strings().companyShortName}</Form.Label>
            <Form.Control type="text" value={companShortName} onChange={(e) => setCompanyShortName(e.target.value)} />
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

export default createCompany;
