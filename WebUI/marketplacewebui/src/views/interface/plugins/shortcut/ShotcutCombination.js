import React, { useState } from 'react';
import { ToggleButton, ToggleButtonGroup } from 'react-bootstrap';

const ShotcutCombination = () => {
  const [checked, setChecked] = useState([]);

  return (
    <>
      <p>
        <kbd>ctrl+shift+1</kbd> <kbd>ctrl+shift+2</kbd> will toggle the buttons below.
      </p>
      <ToggleButtonGroup type="checkbox" className="d-block" value={checked}>
        <ToggleButton id="tbg-check-3" value={1} variant="outline-primary" type="checkbox">
          Checkbox 1
        </ToggleButton>
        <ToggleButton id="tbg-check-4" value={2} variant="outline-secondary" type="checkbox">
          Checkbox 2
        </ToggleButton>
      </ToggleButtonGroup>
    </>
  );
};

export default ShotcutCombination;
