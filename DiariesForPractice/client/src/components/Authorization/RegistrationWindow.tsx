import React, {Component} from "react";
import {RootStore} from "../../stores/RootStore";
import {observer} from "mobx-react";
import {makeObservable, observable} from "mobx";
import {UserReadModel} from "../../Typings/readModels/UserReadModel";
import {Alert, Button, Dropdown, DropdownItem, DropdownMenu, DropdownToggle, Input, Label} from "reactstrap";
import {AuthorizationMode} from "../../consts/AuthorizationMode";
import {translateUserRole} from "../../functions/translater";
import {UserRole} from "../../Typings/enums/UserRole";

class RegistrationWindowProps {
    store: RootStore;
    modeToggle: any;
}

@observer
class RegistrationWindow extends Component<RegistrationWindowProps> {
    user: UserReadModel = new UserReadModel();
    notRegistered: boolean;
    roleOpen: boolean;
    
    constructor(props: RegistrationWindowProps) {
        super(props);
        makeObservable(this, {
          user: observable,
          notRegistered: observable,
          roleOpen: observable,
        });
        this.setDefault();
    }

    setDefault() {
        this.user.role = UserRole.User;
    }
    
    renderWarnings() {
        setTimeout(() => {
            this.notRegistered = false;
        }, 10000);
        return (
            <>
                {this.notRegistered && <Alert>
                    Что-то пошло не так и не удалось зарегистироваться
                </Alert>}
            </>
        );
    }
    
    renderLoginInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Логин
                </Label>
                <Input
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.Login)}
                    placeholder="Введите логин"
                    className="authInput" />
            </div>
        );
    }

    renderPasswordInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Пароль
                </Label>
                <Input
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.Password)}
                    placeholder="Введите пароль"
                    type="password"
                    className="authInput" />
            </div>
        );
    }

    renderFirstNameInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Имя
                </Label>
                <Input
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.FirstName)}
                    placeholder="Введите имя"
                    className="authInput" />
            </div>
        );
    }

    renderSecondNameInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Отчество
                </Label>
                <Input
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.SecondName)}
                    placeholder="Введите отчество"
                    className="authInput" />
            </div>
        );
    }

    renderPhoneInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Телефон
                </Label>
                <Input
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.Phone)}
                    placeholder="Введите телефон"
                    className="authInput" />
            </div>
        );
    }

    renderEmailInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Email
                </Label>
                <Input
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.Email)}
                    placeholder="Введите email"
                    className="authInput" />
            </div>
        );
    }

    renderLastNameInput() {
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Фамилия
                </Label>
                <Input
                    onChange={(event) => this.registrationDataInput(event, RegistrationData.LastName)}
                    placeholder="Введите фамилию"
                    className="authInput" />
            </div>
        );
    }

    renderRole(userRole: UserRole) {
        console.log("userRole", userRole);
        return (
            <div className="row justify-content-center dataBlock">
                <Label className="dataLabel">
                    Роль
                </Label>
                <Dropdown isOpen={this.roleOpen} toggle={() => this.userRoleToggle()} className="dropdownMenu">
                    <DropdownToggle caret className="dropdownToggle">
                        {translateUserRole(userRole)}
                    </DropdownToggle>
                    <DropdownMenu className="">
                        <DropdownItem
                            key={1}
                            onClick={() => this.chooseRole(UserRole.Student)}>
                            {translateUserRole(UserRole.Student)}
                        </DropdownItem>
                        <DropdownItem
                            key={2}
                            onClick={() => this.chooseRole(UserRole.Teacher)}>
                            {translateUserRole(UserRole.Teacher)}
                        </DropdownItem>
                        <DropdownItem
                            key={3}
                            onClick={() => this.chooseRole(UserRole.Admin)}>
                            {translateUserRole(UserRole.Admin)}
                        </DropdownItem>
                    </DropdownMenu>
                </Dropdown>
            </div>
        );
    }
    
    renderButton() {
        return (
            <div className="row justify-content-center">
                <Button
                    className="authButton"
                    outline color="secondary"
                    onClick={() => this.register()}>
                    Зарегистрироваться
                </Button>
            </div>
        );
    }
    
    renderRegistrationWindow() {
        return (
            <div className="container-fluid">
                {this.renderLoginInput()}
                {this.renderEmailInput()}
                {this.renderFirstNameInput()}
                {this.renderSecondNameInput()}
                {this.renderLastNameInput()}
                {this.renderPasswordInput()}
                {this.renderPhoneInput()}
                {this.renderRole(this.user.role)}
                {this.renderButton()}
            </div>
        );
    }
    
    render() {
        return (
            <div className="container-fluid">
                <div className="row justify-content-center">
                    {this.renderWarnings()}
                    {this.renderRegistrationWindow()}
                </div>
            </div>
        );
    }

    registrationDataInput(event: React.FormEvent<HTMLInputElement>, registrationData: RegistrationData) {
        if(registrationData === RegistrationData.Login) {
            this.user.login = event.currentTarget.value;
        } else if(registrationData === RegistrationData.Password) {
            this.user.password = event.currentTarget.value;
        } else if(registrationData === RegistrationData.Email) {
            this.user.email = event.currentTarget.value;
        } else if(registrationData === RegistrationData.FirstName) {
            this.user.firstName = event.currentTarget.value;
        } else if(registrationData === RegistrationData.LastName) {
            this.user.lastName = event.currentTarget.value;
        } else if(registrationData === RegistrationData.SecondName) {
            this.user.secondName = event.currentTarget.value;
        } else if(registrationData === RegistrationData.Phone) {
            this.user.phone = event.currentTarget.value;
        }
    }

    register() {
        this.props.store.userStore.register(this.user)
            .then((status) => {
                if(status === 200) {
                    this.props.modeToggle(AuthorizationMode.Authorization);
                } else {
                    this.notRegistered = true;
                }
            });
    }
    
    chooseRole(role: UserRole) {
        this.user.role = role;
    }

    userRoleToggle() {
        this.roleOpen = !this.roleOpen;
    }
}

export default RegistrationWindow;

enum RegistrationData {
    Login,
    Password,
    FirstName,
    SecondName,
    LastName,
    Email,
    Phone
}