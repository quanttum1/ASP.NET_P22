import { createApi } from '@reduxjs/toolkit/query/react';
import { createBaseQuery } from '../utilities/createBaseQuery.ts';

export interface ILoginRequest {
    email: string;
    password: string;
}

interface ILoginResponse {
    token: string;
}

export const apiAccount = createApi({
    reducerPath: 'api/account',
    baseQuery: createBaseQuery('account'),
    endpoints: (builder) => ({
        login: builder.mutation<ILoginResponse, ILoginRequest>({
            query: (credentials) => ({
                url: 'login',
                method: 'POST',
                body: credentials,
            }),
        }),
    }),
});

export const { useLoginMutation } = apiAccount;