import React, {Component} from "react";
import {observer} from "mobx-react";
import {UserViewModel} from "../../../Typings/viewModels/UserViewModel";
import {Table} from "reactstrap";
import Student from "./Student";
import {GroupViewModel} from "../../../Typings/viewModels/GroupViewModel";
import StudentSearch from "../../Common/Search/StudentSearch";
import InstituteDetailsStore from "../../../stores/InstituteDetailsStore";
import {ActionType} from "../../../consts/ActionType";
import {makeObservable, observable} from "mobx";
import {warningTypeRenderer} from "../../../functions/warningTypeRenderer";
import {WarningType} from "../../../consts/WarningType";

class StudentsProps {
    group: GroupViewModel;
    instituteStore: InstituteDetailsStore;
    groupUpdate: any;
}

@observer
class Students extends Component<StudentsProps> {
    group: GroupViewModel = new GroupViewModel();
    notSaved: boolean;
    saved: boolean;
    edit: boolean;
    removed: boolean;
    notRemoved: boolean;
    
    constructor(props: StudentsProps) {
        super(props);
        makeObservable(this, {
            group: observable,
            notSaved: observable,
            saved: observable,
            removed: observable,
            notRemoved: observable,
            edit: observable,
        });
    }

    renderWarnings() {
        setTimeout(() => {
            this.notSaved = false;
            this.saved = false;
            this.edit = false;
            this.notRemoved = false;
            this.removed = false;
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
    
    renderSearch() {
        return (
            <StudentSearch 
                instituteStore={this.props.instituteStore}
            />
        );
    }
    
    renderStudentsTable(students: UserViewModel[]) {
        return(
            <Table>
                <thead>
                <tr>
                    <th>Id</th>
                    <th>ФИО</th>
                    <th>Процент заполнения</th>
                    <th>Одобрен</th>
                    <th>Контрол</th>
                </tr>
                </thead>
                <tbody>
                    {students.map((student) => {
                        return (
                            <Student student={student} action={this.performActionWithStudent}/>
                        );
                    })}
                </tbody>
            </Table>
        );
    }
    
    render() {
        return(
            <>
                {this.renderStudentsTable(this.group.students)}
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
        this.props.instituteStore.getStudents();
        this.props.groupUpdate();
    }
}

export default Students;