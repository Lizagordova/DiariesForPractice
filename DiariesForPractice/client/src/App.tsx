import React, {Component} from 'react';
import './App.css';
import {RootStore} from "./stores/RootStore";
import {BrowserRouter} from "react-router-dom";
import {observer} from "mobx-react";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-social/bootstrap-social.css';
import "./styles/custom.css";
import AuthorizationPage from "./components/Authorization/AuthorizationPage";
import { UserViewModel } from "./Typings/viewModels/UserViewModel";
import { UserRole } from "./Typings/enums/UserRole";
import AdminMain from "./components/Admin/AdminMain";

interface AppProps {
    store: RootStore;
}

@observer
class App extends Component<AppProps> {
    renderPage(store: RootStore) {
        return(
            <>
                {!store.userStore.authorized && <AuthorizationPage store={store} />}
                {store.userStore.authorized && this.renderPageForUser()}
            </>
            
        );
    }

    renderMain(currentUser: UserViewModel, store: RootStore) {
        if(currentUser.role === UserRole.Admin) {
            return (
                <AdminMain store={store} />
            );
        } else if(currentUser.role === UserRole.Student) {
            return (
                <StudentMain store={store} />
            );
        } else if(currentUser.role === UserRole.Teacher) {
            return (
                <TeacherMain store={store} />
            );
        } else if(currentUser.role === UserRole.User) {
            return (
                <UserMain store={store} />
            );
        }
    }
    
    renderFooter() {
        return (
            <>
                Footer
            </>
        );
    }

    renderPageForUser() {
        return (
            <>
                <main>
                    {this.renderMain()}
                </main>
                <footer>
                    {this.renderFooter()}
                </footer>
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
