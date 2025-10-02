import { createSlice } from "@reduxjs/toolkit/react";

export const uiSlice = createSlice({
    name: 'ui',
    initialState: {
        isLoading: false,
    },
    reducers: {
        startLoading: (state) => {
            state.isLoading = true;
        },
        stopLoading: (state) => {
            state.isLoading = false;
        }
    }
});

export const {startLoading, stopLoading} = uiSlice.actions;