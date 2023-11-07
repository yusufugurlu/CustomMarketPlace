import React, { useEffect } from 'react';
import { useHistory } from 'react-router-dom';
import DataTable from 'customCompanents/DataTables/dataTable';
import { localization } from 'lang/localization';
import {  Form } from 'react-bootstrap';
import { customSweet } from 'customCompanents/swal';
import { commonService } from 'Services/commonService';
import Cookies from 'js-cookie';


const cacheManagment = () => {
  const history = useHistory();

  const [data, setData] = React.useState([]);
  const [isDataLoading, setIsDataLoading] = React.useState(false);

  const getAllKeys = () => {

    setIsDataLoading(true);
    commonService.getAllKeys().then((result) => {
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
    getAllKeys();
  }, []);



  const columns = [
    { Header: localization.strings().name, accessor: 'name', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
    { Header: localization.strings().definition, accessor: 'definition', sortable: true, headerClassName: 'text-muted text-small text-uppercase w-10' },
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

  const handlerDelete = (selectedRowIds) => {
    customSweet.customAlertQuestion(
      localization.strings().delete,
      localization.strings().cacheAlert,
      () => {
        const dtos = [];
        selectedRowIds.forEach((x) => {
          dtos.push(x.id);
        });

        setIsDataLoading(true);
        commonService.deleteDatas(dtos).then((result) => {
          if (result.status === 200) {
            const currentUser = Cookies.get("currentUser");
            if (currentUser) {
                Cookies.remove("currentUser");
            }
            history.push("/login");
          }
          else {
            customSweet.customSweetAlert(result.message, "error", 2000);
          }
          setIsDataLoading(false);
        });

      }
    );
  }


  return (
    <>

      <DataTable
        columnList={columns}
        dataList={data}
        title={localization.strings().cacheManagement}
        isActiveDeleteButton
        handlerDeleteButton={handlerDelete}
        isLoading={isDataLoading}
      />
    </>
  );
};

export default cacheManagment;
