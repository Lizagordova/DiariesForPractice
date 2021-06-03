import React, { Component } from "react";
import { observer } from "mobx-react";
import { GroupViewModel } from "../../../Typings/viewModels/GroupViewModel";
import InstituteDetailsStore from "../../../stores/InstituteDetailsStore";
import UserStore from "../../../stores/UserStore";
import GroupDetails from "./GroupDetails";
import Students from "./Students";
import { Modal } from "reactstrap";

class GroupProps {
    group: GroupViewModel;
    toggle: any;
    instituteStore: InstituteDetailsStore;
    userStore: UserStore;
}

@observer
class Group extends Component<GroupProps> {
    group: GroupViewModel = new GroupViewModel();
    
    constructor(props: GroupProps) {
        super(props);
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
            <Students group={this.group} instituteStore={this.props.instituteStore} groupUpdate={this.groupUpdate}/>
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

    groupUpdate() {
        this.props.instituteStore
            .getGroup(this.group.id)
            .then((group) => {
                if(group.id !== 0) {
                    this.group = group;
                }
            })
    }
}

export default Group;