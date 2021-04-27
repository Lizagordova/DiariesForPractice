import React from 'react';
import { render } from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { RootStore } from "./stores/RootStore";
import { Provider } from  "mobx-react";

const rootElement = document.getElementById("root");
const store = new RootStore();

render(
    <Provider store={store}>
        <App store={store}/>
    </Provider>,
    rootElement
);

reportWebVitals();
