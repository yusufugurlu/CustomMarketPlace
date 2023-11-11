import { createSlice } from '@reduxjs/toolkit';


const initialState = {
    data: null,
};


const signalR = createSlice({
    name: 'signalR',
    initialState,
    reducers: {
        notificationChangeData(state = initialState, action) {
            state.data = action.payload;
        },
    },
});

export const {
    notificationChangeData,
} = signalR.actions;
const signalRReducer = signalR.reducer;

export default signalRReducer;
