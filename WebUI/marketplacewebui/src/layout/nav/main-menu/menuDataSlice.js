import { createSlice } from '@reduxjs/toolkit';


const initialState = {
  isChangeMenu: false,
  menuData: [],
  menuName: "",
  menuDataAll: [],
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
    menuChangeDataAll(state, action) {
      if (action.payload === undefined) {
        state.menuDataAll = [];
      }
      state.menuDataAll = action.payload;
    },
  },
});

export const {
  menuChangeMenu,
  menuChangeData,
  menuChangeName,
  menuChangeDataAll,
} = menuData.actions;
const menuDataSlice = menuData.reducer;

export default menuDataSlice;
