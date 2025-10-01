import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import type { Proizvod } from "../../app/models/proizvod";
import { Link } from "react-router-dom";

interface Props {
    proizvod: Proizvod;
}

export default function ProizvodCard({proizvod}: Props) {
    return (
    <Card
      elevation={3}
        sx={{
            width: 280,
            borderRadius: 2,
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'space-between'
        }}
    >
      <CardMedia
        sx={{ height: 240, backgroundSize: 'cover' }}
        image="http://picsum.photos/200"
        title={proizvod.naziv}
      />
      <CardContent>
        <Typography 
                gutterBottom
                sx={{textTransform: 'uppercase'}} 
                variant="subtitle2">
                {proizvod.naziv}
        </Typography>
        <Typography gutterBottom variant="h6"
                sx={{color: 'secondary.main'}}>
          {proizvod.cena.toFixed(2)} RSD
        </Typography>
        <Typography variant="body2" color="text.secondary">
          {proizvod.opis}
        </Typography>
      </CardContent>
      <CardActions   sx={{justifyContent: 'space-between'}}>
        <Button size="small">Dodaj u korpu</Button>
        <Button component={Link} to={`/catalog/${proizvod.proizvodId}`} size="small">Pogledaj</Button>
      </CardActions>
    </Card>
    )
}