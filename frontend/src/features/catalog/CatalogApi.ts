import { createApi} from "@reduxjs/toolkit/query/react";
import type { ServiceResponseProizvod, ServiceResponseProizvodId } from "../../app/models/serviceResponse";
import { baseQuery } from "../../app/api/baseApi";

export const catalogApi = createApi({
    reducerPath: 'catalogApi',
    baseQuery: baseQuery,
    endpoints: (builder) => ({
        fetchProizvod: builder.query<ServiceResponseProizvod, void>({
            query: () => ({url: 'proizvod'})
        }),
        fetchProizvodDetails: builder.query<ServiceResponseProizvodId, number>({
            query: (proizvodId) => ({url: `proizvod/${proizvodId}`})
        })
    })
});

export const {useFetchProizvodDetailsQuery, useFetchProizvodQuery} = catalogApi;