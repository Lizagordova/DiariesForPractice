import React, { Component } from 'react';
import './App.css';
import { RootStore } from "./stores/RootStore";
import { BrowserRouter } from "react-router-dom";
import { observer } from "mobx-react";
import Main from "./components/Common/Main";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-social/bootstrap-social.css';
import "./styles/custom.css";

interface AppProps {
    store: RootStore;
}

@observer
class App extends Component<AppProps> {
    renderMain() {
        return(
            <Main store={this.props.store} />
        );
    }

    renderFooter() {
        return (
            <>
                Footer
            </>
        );
    }

    render() {
        const { store } = this.props;
        return (
            <div>
                <BrowserRouter>
                    <div className="app">
                        <main>
                            {this.renderMain()}
                        </main>
                        <footer>
                            {this.renderFooter()}
                        </footer>
                    </div>
                </BrowserRouter>
            </div>
        )
    }
}


export default App;
