import React, { useEffect } from 'react';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const CustomNotification = ({ mesaj }) => {
    useEffect(() => {
      const notify = () => toast(mesaj);
      notify();
    }, [mesaj]);
  
    return null;
  };
  

export default CustomNotification;