import classNames from 'classnames';
import React, { useEffect, useRef, useState } from 'react';
import { Button, Col, Dropdown, Form, Row, ButtonGroup, Tooltip, OverlayTrigger, Pagination, Spinner } from 'react-bootstrap';
import { useTable, useGlobalFilter, useSortBy, usePagination, useRowSelect, useRowState, useAsyncDebounce } from 'react-table';
import CsLineIcons from 'cs-line-icons/CsLineIcons';
import { localization } from 'lang/localization';

const DataTable = (
    {
        columnList,
        dataList,
        title,
        isActiveAddButton,
        handlerAddButton,
        isActiveDeleteButton,
        handlerDeleteButton,
        isActiveEditButton,
        handlerEditButton,
        isLoading }) => {
    const columns = React.useMemo(() => columnList, [columnList]);

    const [data, setData] = React.useState([]);

    useEffect(() => {
        if (dataList.length > 0) {
            setData(dataList);
        }
        else{
            setData([]);
        }
    }, [dataList]);

    const [isOpenAddEditModal, setIsOpenAddEditModal] = useState(false);
    const checkAllRef = useRef(null);
    const options = [5, 10, 20];

    const tableInstance = useTable(
        { columns, data, setData, isOpenAddEditModal, setIsOpenAddEditModal, initialState: { pageIndex: 0 } },
        useGlobalFilter,
        useSortBy,
        usePagination,
        useRowSelect,
        useRowState
    );



    const {
        getToggleAllPageRowsSelectedProps,
        selectedFlatRows,
        state: { selectedRowIds },
        setGlobalFilter,
        state: { globalFilter },
        setPageSize,
        gotoPage,
        state: { pageSize },
        getTableProps,
        headerGroups,
        page,
        getTableBodyProps,
        prepareRow,
        canPreviousPage,
        previousPage,
        pageCount,
        nextPage,
        canNextPage,
        state: { pageIndex },
    } = tableInstance;

    const { onChange, checked, indeterminate } = getToggleAllPageRowsSelectedProps();


    useEffect(() => {
        if (checkAllRef.current) {
            checkAllRef.current.indeterminate = indeterminate;
        }
        return () => { };
    }, [indeterminate]);

    const addButtonClick = () => {
        tableInstance.toggleAllPageRowsSelected(false);
        setIsOpenAddEditModal(true);
        handlerAddButton();
    };


    const deleteSelectedItems = () => {
        setData(data.filter((x, index) => selectedRowIds[index] !== true));
    };

    const changeTagSelectedItems = (tag) => {
        const newData = data.map((x, index) => {
            if (selectedRowIds[index] === true) {
                return { ...x, tag };
            }
            return x;
        });
        setData(newData);
    };

    const [value, setValue] = React.useState(globalFilter);
    const onChangeSearch = useAsyncDebounce((val) => {
        setGlobalFilter(val || undefined);
    }, 200);


    const { toggleAllPageRowsSelected } = tableInstance;
    const addButtonControlsAddClick = () => {
        toggleAllPageRowsSelected(false);
        setIsOpenAddEditModal(true);
        handlerAddButton();
    };


    const onClickDelete = () => {
        const selectedDatas = data.filter((x, index) => selectedRowIds[index] === true);
        if (selectedDatas.length > 0) {
            handlerDeleteButton(selectedDatas);
        }
        else {
            handlerDeleteButton([{ id: 0 }]);
        }
    };

    const onSelectPageSize = (size) => {
        setPageSize(size);
        gotoPage(0);
    };

    const handleDropdownSelect = (eventKey) => {
        const selectedSize = parseInt(eventKey, 10);
        onSelectPageSize(selectedSize);
    };


    const handlerButtonEdit = () => {
        const selectedDatas = data.filter((x, index) => selectedRowIds[index] === true);
        if (selectedDatas.length > 0) {
            handlerEditButton(selectedDatas[0]);
        }
        else {
            handlerEditButton([{ id: 0 }]);
        }
    };


    return (
        !isLoading ? (
            <>
                <Row>
                    <Col>
                        <div className="page-title-container">
                            <Row>
                                <Col xs="12" md="7">
                                    <h1 className="mb-4 pb-0 display-4">{title}</h1>
                                </Col>
                                <Col xs="12" md="5" className="d-flex align-items-start justify-content-end">

                                    {isActiveAddButton && (
                                        <Button variant="outline-primary" className="btn-icon btn-icon-start w-100 w-md-auto add-datatable" onClick={addButtonClick}>
                                            <CsLineIcons icon="plus" /> <span>{localization.strings().add}</span>
                                        </Button>
                                    )}

                                    <div className="">
                                        <Dropdown drop="down" as={ButtonGroup} className="ms-1 check-all-container" align="end">
                                            <Button variant="outline-primary" className="btn-custom-control p-0 ps-3 pe-2" onClick={onChange}>
                                                <Form.Check ref={checkAllRef} className="form-check float-end pt-0" type="checkbox" checked={checked} onChange={() => { }} />
                                            </Button>
                                            <Dropdown.Toggle split as={Button} variant="outline-primary" className="" />
                                            <Dropdown.Menu
                                                popperConfig={{
                                                    modifiers: [
                                                        {
                                                            name: 'computeStyles',
                                                            options: {
                                                                gpuAcceleration: false,
                                                            },
                                                        },
                                                    ],
                                                }}
                                            >
                                                <Dropdown drop="start" className="dropdown-submenu">
                                                    <Dropdown.Menu>
                                                        <Dropdown.Item
                                                            href="#/action"
                                                            onClick={(event) => {
                                                                event.preventDefault();
                                                                changeTagSelectedItems('Done');
                                                            }}
                                                        >
                                                            Done
                                                        </Dropdown.Item>
                                                        <Dropdown.Item
                                                            href="#/action"
                                                            onClick={(event) => {
                                                                event.preventDefault();
                                                                changeTagSelectedItems('New');
                                                            }}
                                                        >
                                                            New
                                                        </Dropdown.Item>
                                                        <Dropdown.Item
                                                            href="#/action"
                                                            onClick={(event) => {
                                                                event.preventDefault();
                                                                changeTagSelectedItems('Sale');
                                                            }}
                                                        >
                                                            Sale
                                                        </Dropdown.Item>
                                                    </Dropdown.Menu>
                                                    <Dropdown.Toggle variant="link" disabled={selectedFlatRows.length === 0}>
                                                        Tag
                                                    </Dropdown.Toggle>
                                                </Dropdown>
                                                <Dropdown.Item href="#/action" disabled={selectedFlatRows.length === 0} onClick={deleteSelectedItems}>
                                                    Delete
                                                </Dropdown.Item>
                                            </Dropdown.Menu>
                                        </Dropdown>
                                    </div>
                                </Col>
                            </Row>
                        </div>

                        <div>
                            <Row className="mb-3">
                                <Col sm="12" md="5" lg="3" xxl="2">
                                    <div className="d-inline-block float-md-start me-1 mb-1 mb-md-0 search-input-container w-100 shadow bg-foreground">
                                        <input
                                            className="form-control datatable-search"
                                            value={value || ''}
                                            onChange={(e) => {
                                                setValue(e.target.value);
                                                onChangeSearch(e.target.value);
                                            }}
                                            placeholder={localization.strings().search}
                                        />
                                        {value && value.length > 0 ? (
                                            <span
                                                className="search-delete-icon"
                                                onClick={() => {
                                                    setValue('');
                                                    onChangeSearch('');
                                                }}
                                            >
                                                <CsLineIcons icon="close" />
                                            </span>
                                        ) : (
                                            <span className="search-magnifier-icon pe-none">
                                                <CsLineIcons icon="search" />
                                            </span>
                                        )}
                                    </div>
                                </Col>
                                <Col sm="12" md="7" lg="9" xxl="10" className="text-end">
                                    <div className="d-inline-block me-0 me-sm-3 float-start float-md-none">
                                        {isActiveAddButton && (
                                            <OverlayTrigger placement="top" overlay={<Tooltip id="tooltip-top-add">{localization.strings().add}</Tooltip>}>
                                                <Button onClick={addButtonControlsAddClick} variant="foreground-alternate" className="btn-icon btn-icon-only shadow add-datatable">
                                                    <CsLineIcons icon="plus" />
                                                </Button>
                                            </OverlayTrigger>
                                        )}


                                        {selectedFlatRows.length !== 1 ? (
                                            <>
                                                {isActiveEditButton && (
                                                    <Button variant="foreground-alternate" className="btn-icon btn-icon-only shadow edit-datatable" disabled>
                                                        <CsLineIcons icon="edit" />
                                                    </Button>
                                                )}
                                            </>
                                        ) : (
                                            <>
                                                {isActiveEditButton && (
                                                    <OverlayTrigger placement="top" overlay={<Tooltip id="tooltip-top-edit">{localization.strings().edit}</Tooltip>}>
                                                        <Button onClick={handlerButtonEdit} variant="foreground-alternate" className="btn-icon btn-icon-only shadow edit-datatable">
                                                            <CsLineIcons icon="edit" />
                                                        </Button>
                                                    </OverlayTrigger>
                                                )}
                                            </>
                                        )}

                                        {isActiveDeleteButton && (<OverlayTrigger placement="top" overlay={<Tooltip id="tooltip-top-delete">{localization.strings().delete}</Tooltip>}>
                                            <Button onClick={onClickDelete} variant="foreground-alternate" className="btn-icon btn-icon-only shadow delete-datatable">
                                                <CsLineIcons icon="bin" />
                                            </Button>
                                        </OverlayTrigger>)}

                                    </div>
                                    <div className="d-inline-block">
                                        <OverlayTrigger placement="top" delay={{ show: 1000, hide: 0 }} overlay={<Tooltip>Item Count</Tooltip>}>
                                            {({ ref, ...triggerHandler }) => (
                                                <Dropdown className="d-inline-block" align="end" onSelect={handleDropdownSelect}>
                                                    <Dropdown.Toggle ref={ref} {...triggerHandler} variant="foreground-alternate" className="shadow">
                                                        {pageSize} {localization.strings().rows}
                                                    </Dropdown.Toggle>
                                                    <Dropdown.Menu
                                                        className="shadow dropdown-menu-end"
                                                        popperConfig={{
                                                            modifiers: [
                                                                {
                                                                    name: 'computeStyles',
                                                                    options: {
                                                                        gpuAcceleration: false,
                                                                    },
                                                                },
                                                            ],
                                                        }}
                                                    >
                                                        {options.map((pSize) => (
                                                            <Dropdown.Item key={`pageSize.${pSize}`} eventKey={pSize.toString()} active={pSize === pageSize}>
                                                                {pSize} {localization.strings().rows}
                                                            </Dropdown.Item>
                                                        ))}
                                                    </Dropdown.Menu>
                                                </Dropdown>
                                            )}
                                        </OverlayTrigger>
                                    </div>
                                </Col>
                            </Row>
                            <Row>
                                <Col xs="12">
                                    <table className="react-table rows" {...getTableProps()}>
                                        <thead>
                                            {headerGroups.map((headerGroup, headerIndex) => (
                                                <tr key={`header${headerIndex}`} {...headerGroup.getHeaderGroupProps()}>
                                                    {headerGroup.headers.map((column, index) => {
                                                        return (
                                                            <th
                                                                key={`th.${index}`}
                                                                {...column.getHeaderProps(column.getSortByToggleProps())}
                                                                className={classNames(column.headerClassName, {
                                                                    sorting_desc: column.isSortedDesc,
                                                                    sorting_asc: column.isSorted && !column.isSortedDesc,
                                                                    sorting: column.sortable,
                                                                })}
                                                            >
                                                                {column.render('Header')}
                                                            </th>
                                                        );
                                                    })}
                                                </tr>
                                            ))}
                                        </thead>
                                        <tbody {...getTableBodyProps()}>
                                            {
                                                page.length === 0 ? (
                                                    <tr>
                                                        <td colSpan={columns.length} className="text-center">
                                                            {localization.strings().noRecordFound}
                                                        </td>
                                                    </tr>
                                                ) : (
                                                    page.map((row, i) => {
                                                        prepareRow(row);

                                                        return (
                                                            <tr key={`tr.${i}`} {...row.getRowProps()} className={classNames({ selected: row.isSelected })}>
                                                                {row.cells.map((cell, cellIndex) => (
                                                                    <td
                                                                        key={`td.${cellIndex}`}
                                                                        {...cell.getCellProps()}
                                                                        onClick={() => {
                                                                            if (cell.column.id === 'name') {
                                                                                toggleAllPageRowsSelected(false);
                                                                                row.toggleRowSelected();
                                                                                setIsOpenAddEditModal(true);
                                                                            } else {
                                                                                row.toggleRowSelected();
                                                                            }
                                                                        }}
                                                                    >
                                                                        {cell.render('Cell')}
                                                                    </td>
                                                                ))}
                                                            </tr>
                                                        );
                                                    })
                                                )
                                            }

                                        </tbody>
                                    </table>
                                </Col>
                                <Col xs="12">
                                    <Pagination className="justify-content-center mb-0 mt-3">
                                        <Pagination.First className="shadow" onClick={() => gotoPage(0)} disabled={!canPreviousPage}>
                                            <CsLineIcons icon="arrow-double-left" />
                                        </Pagination.First>
                                        <Pagination.Prev className="shadow" disabled={!canPreviousPage} onClick={() => previousPage()}>
                                            <CsLineIcons icon="chevron-left" />
                                        </Pagination.Prev>
                                        {[...Array(pageCount)].map((x, i) => (
                                            <Pagination.Item key={`pagination${i}`} className="shadow" active={pageIndex === i} onClick={() => gotoPage(i)}>
                                                {i + 1}
                                            </Pagination.Item>
                                        ))}
                                        <Pagination.Next className="shadow" onClick={() => nextPage()} disabled={!canNextPage}>
                                            <CsLineIcons icon="chevron-right" />
                                        </Pagination.Next>
                                        <Pagination.Last className="shadow" onClick={() => gotoPage(pageCount - 1)} disabled={!canNextPage}>
                                            <CsLineIcons icon="arrow-double-right" />
                                        </Pagination.Last>
                                    </Pagination>
                                </Col>
                            </Row>
                        </div>
                    </Col>
                </Row>
            </>
        ) : (
            <>
                <div className="table-loading-spinner">
                    <Spinner animation="border" role="status">
                        <span className="visually-hidden">Yükleniyor...</span>
                    </Spinner>
                </div>
            </>
        )

    );
};

export default DataTable;
