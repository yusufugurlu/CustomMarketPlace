import CustomButton from 'customCompanents/customButton';
import React, { useState } from 'react';
import { Card } from 'react-bootstrap';


const createUser = () => {

  const [isLoading, setIsLLoading] = useState(false);

  const handleClick = () => setIsLLoading(!isLoading);

  return (
    <>
      <Card>
        <Card.Body>
          <CustomButton text='test' onClick={handleClick} isLoading={isLoading}   iconName='plus' size='lg' />

        </Card.Body>
      </Card>
    </>
  );
};

export default createUser;
