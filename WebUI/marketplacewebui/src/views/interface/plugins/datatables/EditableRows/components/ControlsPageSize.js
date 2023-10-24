import React from 'react';
import { Dropdown, OverlayTrigger, Tooltip } from 'react-bootstrap';

const ControlsPageSize = ({ tableInstance }) => {
  const {
    setPageSize,
    gotoPage,
    state: { pageSize },
  } = tableInstance;
  const options = [5, 10, 20];

  const onSelectPageSize = (size) => {
    setPageSize(size);
    gotoPage(0);
  };

  const handleDropdownSelect = (eventKey) => {
    const selectedSize = parseInt(eventKey, 10);
    onSelectPageSize(selectedSize); 
  };

  return (
    <OverlayTrigger placement="top" delay={{ show: 1000, hide: 0 }} overlay={<Tooltip>Item Count</Tooltip>}>
      {({ ref, ...triggerHandler }) => (
        <Dropdown className="d-inline-block" align="end" onSelect={handleDropdownSelect}>
          <Dropdown.Toggle ref={ref} {...triggerHandler} variant="foreground-alternate" className="shadow">
            {pageSize} Items
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
                {pSize} Items
              </Dropdown.Item>
            ))}
          </Dropdown.Menu>
        </Dropdown>
      )}
    </OverlayTrigger>
  );
};

export default ControlsPageSize;
