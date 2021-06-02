import React, {Component} from "react";
import {observer} from "mobx-react";
import {GroupViewModel} from "../../../Typings/viewModels/GroupViewModel";
import {makeObservable, observable} from "mobx";
import {Alert, Button, Input, Label } from "reactstrap";
import InstituteDetailsStore from "../../../stores/InstituteDetailsStore";
import {mapToGroupReadModel} from "../../../functions/mapper";
import {UserViewModel} from "../../../Typings/viewModels/UserViewModel";
import UserStore from "../../../stores/UserStore";

class GroupDetailsProps {
    group: GroupViewModel;
    instituteStore: InstituteDetailsStore;
    userStore: UserStore;
}

@observer
class GroupDetails extends Component<GroupDetailsProps> {
    group: GroupViewModel = new GroupViewModel();
    edit: boolean;
    saved: boolean;
    notSaved: boolean;
    
    constructor(props: GroupDetailsProps) {
        super(props);
        makeObservable(this, {
           group: observable,
           edit: observable,
           saved: observable,
           notSaved: observable,
        });
    }
    
    renderNumberStudents(type: GroupDetailsDataType, edit: boolean) {
        let number = 0;
        if(type === GroupDetailsDataType.NumberRegisteredStudents) {
            number = this.group.groupDetails.numberRegisteredStudents;
        } else if(type === GroupDetailsDataType.NumberStudentsShouldBe) {
            number = this.group.groupDetails.numberStudentsShouldBe;
        } /*else if(type === GroupDetailsDataType.NumberStudentsDiaryCompleted) {
            number = this.group.groupDetails.numberStudentsDiaryCompleted; //todo: доделать
        }*/
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
                    {this.renderNumberStudents(GroupDetailsDataType.NumberStudentsDiaryCompleted, this.edit)}
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
    
    render() {
        return (
            <>
                {this.renderGroupRequirements()}
            </>
        );
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
        //todo: дополнить
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
}

export default GroupDetails;

enum GroupDetailsDataType {
    NumberStudentsShouldBe,
    NumberRegisteredStudents,
    NumberStudentsDiaryCompleted
}