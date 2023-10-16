import { createSlice } from '@reduxjs/toolkit';
import { useSelector } from 'react-redux';


export const languages = [
  { code: 'TR', locale: 'tr-TR', direction: 'ltr' },
  { code: 'EN', locale: 'en-US', direction: 'ltr' },
];

const navigatorLang = (navigator.languages && navigator.languages[0]) || navigator.language || navigator.userLanguage;

const findOrDefault = (key) => {
  return languages.find((x) => x.locale === key || x.code === key) || languages[0];
};

const initialState = {
  languages,
  currentLang: findOrDefault(navigatorLang),
};

const langSlice = createSlice({
  name: 'lang',
  initialState,
  reducers: {
    changeLang(state, action) {
      state.currentLang = findOrDefault(action.payload);
    },
    changeLanguages(state, action) {
      state.languages = action.payload;
    },
  },
});
export const { changeLang, changeLanguages } = langSlice.actions;
const langReducer = langSlice.reducer;

export default langReducer;
