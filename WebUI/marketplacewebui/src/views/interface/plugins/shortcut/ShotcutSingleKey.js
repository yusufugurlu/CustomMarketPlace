import React from 'react';
import { useDispatch, useSelector } from 'react-redux';

const ShortcutSingleKey = () => {
  const dispatch = useDispatch();
  const { color } = useSelector((state) => state.settings);

  return (
    <>
      <p>It's possible to bind single keys to a task.</p>
      <p className="mb-0">
        <kbd>d</kbd> and <kbd>l</kbd> keys toggle dark/light mode.
      </p>
    </>
  );
};

export default ShortcutSingleKey;
