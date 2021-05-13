import React, {Component} from "react";
import {UserViewModel} from "../../../Typings/viewModels/UserViewModel";
import {observer} from "mobx-react";
import {StudentViewModel} from "../../../Typings/viewModels/StudentViewModel";
import {Button} from "reactstrap";
import {ActionType} from "../../../consts/ActionType";
import {translateAction} from "../../../functions/translater";

class StudentProps {
    student: UserViewModel;
    alreadyInGroup: boolean;
    action: any;
}

@observer
class Student extends Component<StudentProps> {
    constructor(props: StudentProps) {
        super(props);
    }
    
    renderStudent(student: StudentViewModel, alreadyInGroup: boolean) {
        return (
            <tr key={student.id}>
                <th>{student.id}</th>
                <th>{this.renderControlForStudent(alreadyInGroup)}</th>
                <th>{this.renderChat()}</th>
            </tr>
        );
    }

    renderControlForStudent(alreadyInGroup: boolean) {
        let action = alreadyInGroup ? ActionType.Remove : ActionType.Add;
        return (
            <Button
                outline color="secondary"
                onClick={() => this.performAction(action)}
            >
                {translateAction(action)}
            </Button>
        );
    }

    renderChat() {
        return (
            <></>
        );
    }
    
    render() {
        return (
            <></>
        );
    }

    performAction(action: ActionType) {
        this.props.action(action, this.props.student);
    }
}

export default Student;