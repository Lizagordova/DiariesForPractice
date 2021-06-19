import React, {Component} from "react";
import {observer} from "mobx-react";
import UserStore from "../../../stores/UserStore";
import {UserViewModel} from "../../../Typings/viewModels/UserViewModel";
import {
    Alert,
    Button,
    CustomInput,
    Dropdown, DropdownItem, DropdownMenu,
    DropdownToggle,
    Form,
    FormGroup,
    Label,
    Modal,
    ModalBody,
    ModalFooter
} from "reactstrap";
import {makeObservable, observable, toJS} from "mobx";
import {mapUserReadModel} from "../../../functions/mapper";
import {UserRole} from "../../../Typings/enums/UserRole";
import {translateUserRole} from "../../../functions/translater";

class AddOrUpdateUserWindowProps {
    userStore: UserStore;
    user: UserViewModel;
    toggle: any;
}

@observer
class AddOrUpdateUserWindow extends Component<AddOrUpdateUserWindowProps> {
    user: UserViewModel = new UserViewModel();
    notSaved: boolean;
    saved: boolean;
    roleOpen: boolean;

    constructor(props: AddOrUpdateUserWindowProps) {
        super(props);
        makeObservable(this, {
            user: observable,
            notSaved: observable,
            saved: observable,
            roleOpen: observable,
        });
        this.setDefault();
    }

    setDefault() {
        this.user = this.props.user;
    }
    
    renderWarnings() {
        setTimeout(() => {
            this.notSaved = false;
            this.saved = false;
        }, 7000);
        return (
            <>
                {this.saved && <Alert color="success">Пользователь удачно сохранился!</Alert>}
                {this.notSaved && <Alert color="danger">Что-то пошло не так, и данные не сохранились.</Alert>}
            </>
        );
    }
    
    renderUserRole(userRole: UserRole) {
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
                    <DropdownMenu className="dropdownMenu">
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

    determineCheckOrNot(userRole: UserRole): boolean {
        return this.user.role === userRole;
    }
    
    chooseRole(userRole: UserRole) {        
        this.user.role = userRole;
    }

    renderAddOrUpdateUserWindow(user: UserViewModel) {
        return (
            <Modal isOpen={true} toggle={() => this.props.toggle()}>
                <div className="row justify-content-center">
                    {user.fio}
                </div>
                <ModalBody>
                    {this.renderUserRole(user.role)}
                </ModalBody>
                <div className="row justify-content-center">
                    <Button
                        className="authButton"
                        outline color="secondary"
                        onClick={() => this.save()}>
                        Сохранить
                    </Button>
                </div>
            </Modal>
        );
    }
    
    render() {
        return (
            <>
                {this.renderAddOrUpdateUserWindow(this.user)}
            </>
        );
    }

    save() {
        let user = mapUserReadModel(this.user);
        this.props.userStore.addOrUpdateUser(user)
            .then((status) => {
               this.saved = status === 200;
               this.notSaved = status !== 200;
            });
    }

    userRoleToggle() {
        this.roleOpen = !this.roleOpen;
    }
}

export default AddOrUpdateUserWindow;