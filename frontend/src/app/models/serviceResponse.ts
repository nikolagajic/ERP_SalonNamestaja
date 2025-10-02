import type { Proizvod } from "./proizvod";

export interface ServiceResponseProizvod {
    data: Proizvod[],
    success: boolean,
    message: string
}

export interface ServiceResponseProizvodId {
    data: Proizvod,
    success: boolean,
    message: string
}