import React, {Component} from "react";
import {observer} from "mobx-react";
import UserStore from "../../../stores/UserStore";
import {UserViewModel} from "../../../Typings/viewModels/UserViewModel";
import {Alert, Button, CustomInput, Form, FormGroup, Label, Modal, ModalBody, ModalFooter} from "reactstrap";
import {makeObservable, observable} from "mobx";
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

    constructor(props: AddOrUpdateUserWindowProps) {
        super(props);
        makeObservable(this, {
            user: observable,
            notSaved: observable,
            saved: observable
        });
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
    
    renderUserData() {
        return (
            <Form>
                <FormGroup>
                    <Label for="exampleCheckbox">Роли</Label>
                    <div>
                        <CustomInput 
                            type="checkbox"
                            checked={this.determineCheckOrNot(UserRole.User)}
                            id={`${UserRole.User}`}
                            label={`${translateUserRole(UserRole.User)}`}
                            onChange={(e) => this.chooseRole(e, UserRole.User)} />
                        <CustomInput 
                            type="checkbox" 
                            id={`${UserRole.Admin}`}
                            checked={this.determineCheckOrNot(UserRole.Admin)}
                            label={`${translateUserRole(UserRole.Admin)}`}
                            onChange={(e) => this.chooseRole(e, UserRole.Admin)}/>
                    </div>
                </FormGroup>
            </Form>
        );
    }

    determineCheckOrNot(userRole: UserRole): boolean {
        return this.user.roles.includes(userRole);
    }
    
    chooseRole(event: React.ChangeEvent<HTMLInputElement>, userRole: UserRole) {
        let userRoles = this.user.roles;
        if(userRoles.includes(userRole)) {
            userRoles = userRoles.filter(ur => ur != userRole);
        } else {
            userRoles.push(userRole);
        }
        this.user.roles = userRoles;
    }

    renderAddOrUpdateUserWindow() {
        return (
            <Modal isOpen={true} onClick={() => this.props.toggle()}>
                <div className="row justify-content-center">
                    
                </div>
                <ModalBody>
                    {this.renderUserData()}
                </ModalBody>
                <ModalFooter>
                    <Button
                        outline color="secondary"
                        onClick={() => this.save()}>
                        Сохранить
                    </Button>
                </ModalFooter>
            </Modal>
        );
    }
    
    render() {
        return (
            <>
                {this.renderAddOrUpdateUserWindow()}
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
}

export default AddOrUpdateUserWindow;