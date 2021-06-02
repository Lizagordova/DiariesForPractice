import React, { Component } from "react";
import { observer } from "mobx-react";
import { GroupViewModel } from "../../../Typings/viewModels/GroupViewModel";
import InstituteDetailsStore from "../../../stores/InstituteDetailsStore";
import UserStore from "../../../stores/UserStore";
import GroupDetails from "./GroupDetails";
import { UserViewModel } from "../../../Typings/viewModels/UserViewModel";
import { Modal, Table } from "reactstrap";
import Student from "./Student";
import { ActionType } from "../../../consts/ActionType";
import { makeObservable, observable } from "mobx";
import { warningTypeRenderer } from "../../../functions/warningTypeRenderer";
import { WarningType } from "../../../consts/WarningType";

class GroupProps {
    group: GroupViewModel;
    toggle: any;
    instituteStore: InstituteDetailsStore;
    userStore: UserStore;
}

@observer
class Group extends Component<GroupProps> {
    group: GroupViewModel = new GroupViewModel();
    notSaved: boolean;
    saved: boolean;
    edit: boolean;
    removed: boolean;
    notRemoved: boolean;
    
    constructor(props: GroupProps) {
        super(props);
        makeObservable(this, {
            group: observable,
            notSaved: observable,
            saved: observable,
            removed: observable,
            notRemoved: observable,
            edit: observable,
        })
    }

    renderWarnings() {
        setTimeout(() => {
            this.notSaved = false;
            this.saved = false;
            this.edit = false;
        }, 6000);
        return(
            <>
                {this.saved && warningTypeRenderer(WarningType.Saved)}
                {this.notSaved && warningTypeRenderer(WarningType.NotSaved)}
                {this.removed && warningTypeRenderer(WarningType.Removed)}
                {this.notRemoved && warningTypeRenderer(WarningType.NotRemoved)}
            </>
        );
    }
    
    renderGroupDetails() {
        return (
            <GroupDetails  
                group={this.props.group}
                instituteStore={this.props.instituteStore}
                userStore={this.props.userStore}/>
        );
    }

    

    renderStudents() {
        return (
            <>
                {this.renderStudentsTable(new Array<UserViewModel>())}
            </>
        );
    }
    
    renderGroup(group: GroupViewModel) {
        return (
            <Modal isOpen={true} onClick={() => this.props.toggle()}>
                <div className="row justify-content-center">
                    Группа {group.name}
                </div>
                <div className="row justify-content-center">
                    <div className="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        {this.renderGroupDetails()}
                    </div>
                    <div className="col-lg-9 col-md-9 col-sm-12 col-xs-12">
                        {this.renderStudents()}
                    </div>
                </div>
            </Modal>
        );
    }
    
    render() {
        return (
            <>
                {this.renderGroup(this.props.group)}
            </>
        );
    }

    performActionWithStudent(action: ActionType, student: UserViewModel) {
        if(action === ActionType.Remove) {
            this.props.instituteStore
                .removeStudentFromGroup(student.id, this.group.id)
                .then((status) => {
                    this.removed = status === 200;
                    this.notRemoved = status !== 200;
                });
        } else if(action === ActionType.Add) {
            this.props.instituteStore
                .attachStudentToGroup(student.id, this.group.id)
                .then((status) => {
                    this.saved = status === 200;
                    this.notSaved = status !== 200;
                });
        }
    }
}

export default Group;