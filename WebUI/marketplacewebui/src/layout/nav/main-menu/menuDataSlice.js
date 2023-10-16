import { createSlice } from '@reduxjs/toolkit';


const initialState = {
  isChangeMenu: false,
  menuData: [],
  menuName: "",
};

const menuData = createSlice({
  name: 'menuData',
  initialState,
  reducers: {
    menuChangeMenu(state, action) {
      state.isChangeMenu = action.payload;
    },
    menuChangeData(state, action) {
      if (action.payload === undefined) {
        state.menuData = [];
      }
      state.menuData = action.payload;
    },
    menuChangeName(state, action) {
      state.menuName = action.payload;
    },
  },
});

export const {
  menuChangeMenu,
  menuChangeData,
  menuChangeName,
} = menuData.actions;
const menuDataSlice = menuData.reducer;

export default menuDataSlice;
