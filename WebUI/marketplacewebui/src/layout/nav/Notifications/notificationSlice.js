import { createSlice } from '@reduxjs/toolkit';
import axios from 'axios';
import { SERVICE_URL } from 'config.js';

const initialState = {
  status: 'idle',
  notificationItems: [],
  isChangeNotification: false,
};

const notificationSlice = createSlice({
  name: 'notification',
  initialState,
  reducers: {

    notificationsIsChange(state, action) {
      state.isChangeNotification = action.payload;
    },
    notificationsitems(state, action) {
      state.notificationItems = action.payload;
    },
  },
});

export const { notificationsIsChange,notificationsitems } = notificationSlice.actions;

const notificationReducer = notificationSlice.reducer;
export default notificationReducer;
