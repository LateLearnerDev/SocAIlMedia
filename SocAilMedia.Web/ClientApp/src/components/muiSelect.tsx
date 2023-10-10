import {Box, MenuItem, TextField} from "@mui/material";
import React, {useState} from "react";
import '../App.css';

export const MuiSelect = () => {
    const [countries, setCountries] = useState<string[]>([]);
    console.log({country: countries});
    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const value = event.target.value;
        console.log({type: typeof value});
        console.log({value: value});
        setCountries(typeof value === 'string' ? value.split(',') : value);
    };

    return <Box width={'250px'}>
        {/*<TextField label={'Select Country'} select value={country} onChange={handleChange} fullWidth>*/}
        {/*    <MenuItem value={'IN'}>India</MenuItem>*/}
        {/*    <MenuItem value={'US'}>USA</MenuItem>*/}
        {/*    <MenuItem value={'AU'}>Australia</MenuItem>*/}
        {/*</TextField>*/}
        <TextField
            label={'Select Country'}
            select
            value={countries}
            onChange={handleChange}
            fullWidth
            SelectProps={{
                multiple: true
            }}    
            size={"small"}
            color={"secondary"}
            helperText={"Please select your country."}
        >
            <MenuItem value={'IN'}>India</MenuItem>
            <MenuItem value={'US'}>USA</MenuItem>
            <MenuItem value={'AU'}>Australia</MenuItem>
        </TextField>
    </Box>

}