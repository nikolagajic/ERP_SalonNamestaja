import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, Box, IconButton, LinearProgress, List, ListItem, Toolbar, Typography } from "@mui/material";
import { NavLink } from "react-router-dom";
import { useAppSelector } from "../store/store";

const rightLinks = [
    {title: 'prijava', path:'/login'},
    {title: 'registracija', path:'/register'}
]

const navStyles = {
    color: 'inherit',
    typography: 'h6',
    textDecoration: 'none',
    '&:hover': {
        color: 'grey.500'
    }
    
}

export default function Header() {

    const {isLoading} = useAppSelector(state => state.ui);

    return (
    <>
        <AppBar postion='static'>
            <Toolbar sx={{display: 'flex', justifyContent:'space-between', alignItems:'center'}}>
                <Typography variant='h6' component={NavLink} to='/catalog' sx={navStyles}>
                    SALON
                </Typography>
                <Box display='flex' alignItems='center'> 
                <IconButton size='large' edge='start' color='inherit' sx={{mr: 2}}>
                    <Badge badgeContent='4' color='secondary'>
                        <ShoppingCart/>
                    </Badge>
                </IconButton>
                <List sx={{display: 'flex'}}>
                    {rightLinks.map(({title, path}) => (
                        <ListItem component={NavLink} to={path} key={path} sx={navStyles}>
                            {title.toUpperCase()}
                        </ListItem>
                    ))}
                </List>
                </Box>
            </Toolbar>
              {isLoading && (
                <Box sx={{width: '100%'}}>
                    <LinearProgress color="secondary" />
                </Box>
            )}
        </AppBar>
        <Toolbar sx={{mb: 4}}/>
    </>
    )
}