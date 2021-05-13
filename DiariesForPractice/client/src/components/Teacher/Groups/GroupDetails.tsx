import React, {Component} from "react";
import {observer} from "mobx-react";
import {GroupViewModel} from "../../../Typings/viewModels/GroupViewModel";
import {makeObservable, observable} from "mobx";
import {Alert, Button, Input, Label, Modal, ModalBody, ModalFooter, Table} from "reactstrap";
import InstituteDetailsStore from "../../../stores/InstituteDetailsStore";
import {mapToGroupReadModel} from "../../../functions/mapper";
import {UserViewModel} from "../../../Typings/viewModels/UserViewModel";
import Student from "./Student";
import {ActionType} from "../../../consts/ActionType";
import UserStore from "../../../stores/UserStore";
import {UserRole} from "../../../Typings/enums/UserRole";

class GroupDetailsProps {
    group: GroupViewModel;
    isResponsible: boolean;
    toggle: any;
    instituteStore: InstituteDetailsStore;
    userStore: UserStore;
}

@observer
class GroupDetails extends Component<GroupDetailsProps> {
    group: GroupViewModel = new GroupViewModel();
    notSaved: boolean;
    saved: boolean;
    edit: boolean;
    studentsByGroup: UserViewModel[] = new Array<UserViewModel>();
    restStudents: UserViewModel[] = new Array<UserViewModel>();
    
    constructor(props: GroupDetailsProps) {
        super(props);
        makeObservable(this, {
           group: observable,
            notSaved: observable,
            saved: observable,
            edit: observable,
            studentsByGroup: observable,
            restStudents: observable,
        });
    }

    setData() {
        let students = this.props.userStore.users.filter(u => u.roles.includes(UserRole.Student));
        let studentsByGroup = this.props.group.students;
       //todo: доделать
    }
    renderWarnings() {
        setTimeout(() => {
            this.notSaved = false;
            this.saved = false;
            this.edit = false;
        }, 6000);
        return(
            <>
                {this.saved && <Alert color="success">Данные успешно сохранены!</Alert>}
                {this.notSaved && <Alert color="danger">Что-то пошло не так, и данные не сохранились</Alert>}
            </>
        );
    }
    
    renderNumberStudents(type: GroupDetailsDataType, edit: boolean) {
        let number = 0;
        if(type === GroupDetailsDataType.NumberRegisteredStudents) {
            number = this.group.groupDetails.numberRegisteredStudents;
        } else if(type === GroupDetailsDataType.NumberStudentsShouldBe) {
            number = this.group.groupDetails.numberStudentsShouldBe;
        }
        return (
            <>
                {!edit && <span>{number}</span>}
                {edit && <>
                    <Label>
                        {this.getLabelForType(type)}
                    </Label>
                    <Input
                    value={number}
                    onChange={(event) => this.changeNumberStudents(event, type)}
                    />
                </>}
            </>
        );
    }
    
    renderGroupRequirements() {
        return (
            <>
                <div className="row justify-content-center">
                    {this.renderNumberStudents(GroupDetailsDataType.NumberRegisteredStudents, this.edit)}
                </div>
                <div className="row justify-content-center">
                    {this.renderNumberStudents(GroupDetailsDataType.NumberStudentsShouldBe, this.edit)}
                </div>
                <div className="row justify-content-center">
                    {this.renderButton(this.edit)}
                </div>
            </>
        );
    }

    renderButton(edit: boolean) {
        if(edit) {
            return (
                <Button
                    outline color="secondary"
                    onClick={() => this.save()}>
                    Сохранить
                </Button>
            );
        } else {
            return (
                <Button
                    outline color="secondary"
                    onClick={() => this.editToggle()}
                    >
                    Редактировать
                </Button>
            );
        }
    }
    
    renderStudentsTable(students: UserViewModel[], alreadyInGroup: boolean) {
        return(
            <Table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>ФИО</th>
                        <th>Контрол</th>
                        <th>Чат</th>
                    </tr>
                </thead>
                <tbody>
                {students.map((student) => {
                    return (
                       <Student action={this.performActionWithStudent} alreadyInGroup={alreadyInGroup} student={student}/>
                    );
                })}
                </tbody>
            </Table>
        );
    }

    renderStudents() {
        return (
            <>
                {this.renderStudentsTable(new Array<UserViewModel>(), true)}
                {this.renderStudentsTable(new Array<UserViewModel>(), false)}
            </>
        );
    }
    
    renderGroupDetails(group: GroupViewModel) {
        return (
            <Modal isOpen={true} onClick={() => this.props.toggle()}>
                {this.renderWarnings()}
                <div className="row justify-content-center">
                    Группа {group.name}
                </div>
                <ModalBody>
                    {this.renderGroupRequirements()}
                    {this.renderStudents()}
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
                {this.renderGroupDetails(this.group)}
            </>
        );
    }
    
    toggleWindow() {
        this.props.toggle();
    }

    save() {
        let group = mapToGroupReadModel(this.group);
        this.props.instituteStore
            .addOrUpdateGroup(group)
            .then((status) => {
                this.saved = status === 200;
                this.notSaved = status !== 200;
                this.edit = status !== 200;
            });        
    }
    
    changeNumberStudents(event: React.ChangeEvent<HTMLInputElement>, groupDetailsType: GroupDetailsDataType) {
        let value = event.currentTarget.value;
        if(groupDetailsType === GroupDetailsDataType.NumberStudentsShouldBe) {
            this.group.groupDetails.numberStudentsShouldBe = Number(value);
        } else if(groupDetailsType === GroupDetailsDataType.NumberRegisteredStudents) {
            this.group.groupDetails.numberRegisteredStudents = Number(value);
        }
    }
    
    getLabelForType(type: GroupDetailsDataType) {
        let label = "";
        if(type === GroupDetailsDataType.NumberStudentsShouldBe) {
            label = "Количество студентов, которые должны зарегистрироваться";
        } else if(type === GroupDetailsDataType.NumberRegisteredStudents) {
            label = "Количество зарегистрированных студентов";
        }
        
        return label;
    }
    
    editToggle() {
        this.edit = !this.edit;
    }

    performActionWithStudent(action: ActionType, student: UserViewModel) {
        if(action === ActionType.Remove) {
            
        } else if(action === ActionType.Add) {
            
        }
    }
}

export default GroupDetails;

enum GroupDetailsDataType {
    NumberStudentsShouldBe,
    NumberRegisteredStudents
}