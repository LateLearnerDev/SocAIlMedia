import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import {MuiTypography} from "./components/muiTypography";
import {MuiButton} from "./components/muiButton";
import {MuiTextField} from "./components/muiTextField";
import {MuiSelect} from "./components/muiSelect";
import {MuiRadioButton} from "./components/muiRadioButton";

ReactDOM.createRoot(document.getElementById('root')!).render(
    <MuiRadioButton/>
    // <MuiSelect/>
    // <MuiTextField/>
    // <MuiButton/>
    // <MuiTypography/>
    // <App />
,
)
