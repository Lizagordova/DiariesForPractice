import React, { Component } from "react";
import { UserViewModel } from "../../../Typings/viewModels/UserViewModel";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import { ActionType } from "../../../consts/ActionType";
import { Button } from "reactstrap";

class StudentProps {
    student: UserViewModel;
    action: any;
}

@observer
class Student extends Component<StudentProps> {
    studentWindowOpen: boolean;
    
    constructor(props: StudentProps) {
        super(props);
        makeObservable(this, {
            studentWindowOpen: observable
        });
    }
    
    renderStudent(student: UserViewModel) {
        return (
            <tr key={student.id} onDoubleClick={() => this.studentWindowToggle()}>
                <th>{student.id}</th>
                <th>{student.fio}</th>
                <th>{student.fio}</th>
                <th>{student.fio}</th>
                <th>
                    <Button
                        color="primary"
                        onClick={() => this.removeStudent()}>
                        Удалить
                    </Button>
                </th>
            </tr>
        );
    }
    
    render() {
        return (
            <>
                {this.renderStudent(this.props.student)}
            </>
        );
    }

    removeStudent() {
        let result = window.confirm(`Вы уверены, что хотите удалить этого студента?`);
        if(result) {
            this.props.action(ActionType.Remove, this.props.student);
        }
    }

    studentWindowToggle() {
        this.studentWindowOpen = !this.studentWindowOpen;
    }
}

export default Student;