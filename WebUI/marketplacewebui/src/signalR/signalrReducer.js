import { createSlice } from '@reduxjs/toolkit';


const initialState = {
    data: null,
};


const signalR = createSlice({
    name: 'signalR',
    initialState,
    reducers: {
        menuChangeData(state = initialState, action) {
            switch (action.type) {
                case "RECEIVE_DATA":
                    return {
                        ...state,
                        data: action.payload,
                    };
                default:
                    return state;
            }
        },
    },
});

export const {
    menuChangeData,
} = signalR.actions;
const signalRReducer = signalR.reducer;

export default signalRReducer;
