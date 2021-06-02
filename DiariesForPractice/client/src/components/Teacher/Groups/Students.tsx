import React, { Component } from "react";
import { observer } from "mobx-react";
import { UserViewModel } from "../../../Typings/viewModels/UserViewModel";
import { Table } from "reactstrap";
import Student from "./Student";
import { GroupViewModel } from "../../../Typings/viewModels/GroupViewModel";
import StudentSearch from "../../Common/Search/StudentSearch";
import InstituteDetailsStore from "../../../stores/InstituteDetailsStore";

class StudentsProps {
    group: GroupViewModel;
    instituteStore: InstituteDetailsStore;
}

@observer
class Students extends Component<StudentsProps> {
    group: GroupViewModel = new GroupViewModel();
    constructor(props: StudentsProps) {
        super(props);
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
                            <Student student={student}/>
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
}