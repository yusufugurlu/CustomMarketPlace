// src/components/SignalRListener.js

import { useEffect } from "react";
import { connect, useDispatch } from "react-redux";
import connection from "./connection";
import { receiveData } from "./signalRActions";
import { notificationChangeData } from "./signalrReducer";

const SignalRListener = ({ receiveData1 }) => {
  const dispatch = useDispatch();
  useEffect(() => {
    connection.on("ReceiveMessage", (data) => {
      dispatch(notificationChangeData(data));
    });
  }, [receiveData]);

  return null; // Bu bileşen, arayüzde görünmez ve sadece SignalR iletişimi için kullanılır.
};

export default connect(null, { receiveData })(SignalRListener);
