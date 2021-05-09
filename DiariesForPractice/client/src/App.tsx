import React, {Component} from 'react';
import './App.css';
import { RootStore } from "./stores/RootStore";
import { BrowserRouter } from "react-router-dom";
import { observer } from "mobx-react";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-social/bootstrap-social.css';
import "./styles/custom.css";
import AuthorizationPage from "./components/Authorization/AuthorizationPage";
import { UserViewModel } from "./Typings/viewModels/UserViewModel";
import { UserRole } from "./Typings/enums/UserRole";
import AdminMain from "./components/Admin/AdminMain";
import StudentMain from "./components/Student/StudentMain";
import TeacherMain from "./components/Teacher/TeacherMain";
import UserMain from "./components/User/UserMain";

interface AppProps {
    store: RootStore;
}

@observer
class App extends Component<AppProps> {
    renderPage(store: RootStore) {
        return(
            <>
                {!store.userStore.authorized && <AuthorizationPage store={store} />}
                {store.userStore.authorized && this.renderPageForUser(store)}
            </>
        );
    }

    renderMain(currentUser: UserViewModel, store: RootStore) {
        if(currentUser.roles.includes(UserRole.Admin)) {
            return (
                <AdminMain store={store} />
            );
        } else if(currentUser.roles.includes(UserRole.Student)) {
            return (
                <StudentMain store={store} />
            );
        } else if(currentUser.roles.includes(UserRole.Teacher)) {
            return (
                <TeacherMain store={store} />
            );
        } else if(currentUser.roles.includes(UserRole.User)) {
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

    renderPageForUser(store: RootStore) {
        return (
            <>
                <main>
                    {this.renderMain(store.userStore.currentUser, store)}
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
                        {this.renderPage(store)}
                    </div>
                </BrowserRouter>
            </div>
        );
    }
}


export default App;
