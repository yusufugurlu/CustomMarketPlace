// src/components/SignalRListener.js

import { useEffect } from "react";
import { connect } from "react-redux";
import connection from "./connection";
import { receiveData } from "./signalRActions";

const SignalRListener = ({ receiveData1 }) => {
  useEffect(() => {
    connection.on("ReceiveData", (data) => {
      receiveData(data);
    });
  }, [receiveData]);

  return null; // Bu bileşen, arayüzde görünmez ve sadece SignalR iletişimi için kullanılır.
};

export default connect(null, { receiveData })(SignalRListener);
