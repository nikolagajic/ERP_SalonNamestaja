import { fetchBaseQuery, type BaseQueryApi, type FetchArgs } from "@reduxjs/toolkit/query/react";
import { startLoading, stopLoading } from "../layout/uiSlice";
import { router } from "../router/routes";

const customBaseQuery = fetchBaseQuery({
    baseUrl: 'https://localhost:5001/api'
});

const sleep = () => new Promise(resolve => setTimeout(resolve, 1000));

export const baseQuery = async (args: string | FetchArgs, api: BaseQueryApi, 
    extraOptions: object) => {
    api.dispatch(startLoading());
    await sleep();
    const result = await customBaseQuery(args, api, extraOptions);
    api.dispatch(stopLoading());
    if (result.error) {
        const {status, data} = result.error;
        console.log({status, data});
        switch (status) {
            case 404:
                router.navigate('/not-found');
                break;
            case 500:
                router.navigate('/server-error');
                break;
            default:
                break;
        }
    }

    return result;
}