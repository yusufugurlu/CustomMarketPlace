import React, { useEffect } from 'react';
import DataTable from 'customCompanents/DataTables/dataTable';
import { workplaceService } from 'Services/workplaceService';
import { localization } from 'lang/localization';
import { Button, Form, Modal } from 'react-bootstrap';
import { customSweet } from 'customCompanents/swal';
import { rolePermissionService } from 'Services/rolePermissionService';
import { useDispatch } from 'react-redux';
import { setAuthWorkplace } from 'auth/authSlice';
import CustomFormCheckbox from 'customCompanents/customFormCheckbox';



const adminWorkplaces = () => {
  const dispatch = useDispatch();
  const [data, setData] = React.useState([]);
  const [isDataLoading, setIsDataLoading] = React.useState(false);
  const [isOpenAddModal, setIsOpenAddModal] = React.useState(false);
  const [workplaceName, setWorkplaceName] = React.useState("");
  const [code, setCode] = React.useState("");
  const [vkn, setVkn] = React.useState("");
  const [workplaceId, setWorkplaceId] = React.useState(0);
  const [isActive, setIsActive] = React.useState(false);

  const getWorkplaces = () => {

    setIsDataLoading(true);
    workplaceService.getWorkPlaces().then((result) => {
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
    getWorkplaces();
  }, []);



  const handlerEdit = (selectedRowIds) => {
    workplaceService.getWorkPlace({ id: selectedRowIds.id }).then((result) => {
      if (result.status === 200) {
        setWorkplaceId(selectedRowIds.id);
        setWorkplaceName(result.data.name);
        setVkn(result.data.vkn);
        setCode(result.data.code);
        setIsActive(result.data.isActive);
        setIsOpenAddModal(true);
      }
      else {
        customSweet.customSweetAlert(result.message, result.status, 2000);
      }
    });

  }

  const columns = [
    {
      Header: localization.strings().shopName,
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
    { Header: localization.strings().code, accessor: 'code', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
    { Header: localization.strings().vkn, accessor: 'vkn', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
    { Header: localization.strings().isActive, accessor: 'isActiveByLang', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
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
    setWorkplaceName("");
    setVkn("");
    setIsOpenAddModal(false);
    setWorkplaceId(0);
    setIsActive(false);
    setCode("");
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
          workplaceIds: dtos
        };

        setIsDataLoading(true);
        workplaceService.deleteWorkPlaces(dto).then((result) => {
          if (result.status === 200) {
            getWorkplaces();
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


  const sendShop = () => {
    rolePermissionService.getWorkplaces().then((res) => {
      if (res.status === 200) {
        dispatch(setAuthWorkplace(res.data));
      }
    });
  }

  const handleSave = (e) => {
    if (data.length >= 3) {
      setIsOpenAddModal(false);
      customSweet.customSweetAlert("Maksimum 3 adet mağaza tanımlayabilirsiniz.", "error", 2000);
      return;
    }

    const dto = {
      "id": workplaceId,
      "name": workplaceName,
      "vkn": vkn,
      "code": code,
      "isActive": isActive,
    }

    setIsDataLoading(true);
    workplaceService.createWorkPlace(dto).then((result) => {
      if (result.status === 200) {
        customSweet.customSweetAlert(result.message, "success", 2000);
        getWorkplaces();
      }
      else {
        customSweet.customSweetAlert(result.message, "error", 2000);
      }
      sendShop();
      setIsOpenAddModal(false);
    });

  }

  const handleCheckChange = (e) => {
    setIsActive(e.target.checked);
}

  return (
    <>

      <DataTable
        columnList={columns}
        dataList={data}
        title={localization.strings().shopDefinition}
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
          <Modal.Title>{workplaceId === 0 ? localization.strings().add : localization.strings().edit}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="mb-3">
            <Form.Label>{localization.strings().code}</Form.Label>
            <Form.Control type="text" value={code} onChange={(e) => setCode(e.target.value)} />
          </div>

          <div className="mb-3">
            <Form.Label>{localization.strings().shopName}</Form.Label>
            <Form.Control type="text" value={workplaceName} onChange={(e) => setWorkplaceName(e.target.value)} />
          </div>
          <div className="mb-3">
            <Form.Label>{localization.strings().vkn}</Form.Label>
            <Form.Control type="text" value={vkn} onChange={(e) => setVkn(e.target.value)} />
          </div>

          <div className="mb-3">
            <CustomFormCheckbox
              id="customSwitch"
              labelOn={localization.strings().active}
              label={localization.strings().isActive}
              value={isActive}
              onChange={handleCheckChange}
            />
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

export default adminWorkplaces;
