import {configureStore} from "@reduxjs/toolkit";
import {apiCategory} from "../services/apiCategory.ts";
import {apiAccount} from "../services/apiAccount.tsx";
import authReducer from './authSlice.ts';


export const store = configureStore({
    reducer: {
        [apiCategory.reducerPath]: apiCategory.reducer,
        [apiAccount.reducerPath]: apiAccount.reducer,
        auth: authReducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(apiCategory.middleware, apiAccount.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;


