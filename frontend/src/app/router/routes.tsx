import { createBrowserRouter, Navigate } from "react-router-dom";
import ProizvodDetails from "../../features/catalog/ProizvodDetails";
import Catalog from "../../features/catalog/Catalog";
import App from "../layout/App";
import ServerError from "../errors/ServerError";
import NotFoundError from "../errors/NotFoundError";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            {
                path: '/catalog',
                element: <Catalog />
            },
            {
                path: '/catalog/:id',
                element: <ProizvodDetails />
            },
            {
                path: '/server-error',
                element: <ServerError />
            },
            {
                path: '/not-found',
                element: <NotFoundError />
            },   
            {
                path: '*',
                element: <Navigate replace to='/not-found' />
            },
            {
                path: '',
                element: <Navigate replace to='/catalog' />
            }
        ]
    }
])