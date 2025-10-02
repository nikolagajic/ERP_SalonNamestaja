import { useFetchProizvodQuery } from "./CatalogApi";
import ProizvodList from "./ProizvodList";

export default function Catalog(){

    const {data, isLoading} = useFetchProizvodQuery();

    if(isLoading || !data) {
        return <div>Učitavanje...</div>
    }
   
    return (
    <>
        <ProizvodList proizvodi={data.data}></ProizvodList>     
    </>
    )
}
