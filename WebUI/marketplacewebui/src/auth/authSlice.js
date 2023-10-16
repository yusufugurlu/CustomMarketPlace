import { createSlice } from '@reduxjs/toolkit';
import { DEFAULT_USER, IS_DEMO } from 'config.js';

const initialState = {
  isLogin: false,
  currentUser: {},
  token: {},
};

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    setCurrentUser(state, action) {
      state.currentUser = action.payload;
      state.isLogin = false;
    },
    setIsLogin(state, action) {
      state.isLogin = action.payload;
    },
    setToken(state, action) {
      state.token = action.payload;
    },
  },
});

export const { setCurrentUser, setIsLogin, setToken } = authSlice.actions;
const authReducer = authSlice.reducer;

export default authReducer;
