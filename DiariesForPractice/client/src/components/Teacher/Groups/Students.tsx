import React, {Component} from "react";
import {observer} from "mobx-react";
import {UserViewModel} from "../../../Typings/viewModels/UserViewModel";
import {Table} from "reactstrap";
import Student from "./Student";
import {GroupViewModel} from "../../../Typings/viewModels/GroupViewModel";
import StudentSearch from "../../Common/Search/StudentSearch";
import {ActionType} from "../../../consts/ActionType";
import {makeObservable, observable} from "mobx";
import {warningTypeRenderer} from "../../../functions/warningTypeRenderer";
import {WarningType} from "../../../consts/WarningType";
import {RootStore} from "../../../stores/RootStore";

class StudentsProps {
    group: GroupViewModel;
    store: RootStore;
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
                instituteStore={this.props.store.instituteDetailsStore}
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
                            <Student 
                                student={student} 
                                action={this.performActionWithStudent} 
                                store={this.props.store}/>
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
        let { instituteDetailsStore } = this.props.store;
        if(action === ActionType.Remove) {
            instituteDetailsStore
                .removeStudentFromGroup(student.id, this.group.id)
                .then((status) => {
                    this.removed = status === 200;
                    this.notRemoved = status !== 200;
                });
        } else if(action === ActionType.Add) {
            instituteDetailsStore
                .attachStudentToGroup(student.id, this.group.id)
                .then((status) => {
                    this.saved = status === 200;
                    this.notSaved = status !== 200;
                });
        }
        instituteDetailsStore.getStudents();
        this.props.groupUpdate();
    }
}

export default Students;