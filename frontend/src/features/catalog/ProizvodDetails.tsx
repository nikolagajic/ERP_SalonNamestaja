import { useParams } from "react-router-dom";
import { Divider, Grid, Typography, Table, TableContainer, TableBody, TableRow, TableCell, Grid2, Button, TextField } from "@mui/material";
import { useFetchProizvodDetailsQuery } from "./CatalogApi";

export default function ProizvodDetails() {

    const {id} = useParams<{id : string}>();

    const{data, isLoading} = useFetchProizvodDetailsQuery(id ? +id : 0);
   
    if (isLoading || !data) return <h3>Ucitavanje...</h3>

    const proizvod = data.data;

    return (
        <Grid container spacing={6}>
            <Grid item xs={6}>
                <img src='http://picsum.photos/200' alt={proizvod.naziv} style={{width: '100%'}} />
            </Grid>
            <Grid item xs={6}>
                <Typography variant='h3'>{data.data.naziv}</Typography>
                <Divider sx={{mb: 2}}/>
                <Typography variant='h4' color='secondary'>{proizvod.cena} RSD</Typography>
                <TableContainer>
                    <Table>
                        <TableBody>
                            <TableRow>
                                <TableCell>Naziv</TableCell>
                                <TableCell>{proizvod.naziv}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Opis</TableCell>
                                <TableCell>{proizvod.opis}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Materijal</TableCell>
                                <TableCell>{proizvod.materijal}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Na stanju</TableCell>
                                <TableCell>{proizvod.stanje}</TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
                <Grid2 container spacing={2} marginTop={3}>
                    <Grid2 size={6}>
                    <TextField
                        variant="outlined"
                        type="number"
                        label='Količina'
                        fullWidth
                        defaultValue={1}
                   />
                    </Grid2>
                    <Grid2 size={6}>
                        <Button
                            sx={{height: '55px'}}
                            color="primary"
                            size="large"
                            variant="contained"
                            fullWidth
                        >
                            Dodaj u korpu
                        </Button>
                    </Grid2>
                </Grid2>
            </Grid>
        </Grid>
    )
}