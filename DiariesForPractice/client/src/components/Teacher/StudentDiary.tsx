import React, { Component}  from "react";
import { observer } from "mobx-react";
import { Button } from "reactstrap";
import Diary from "../Student/HomePage/Diary/Diary";
import { UserViewModel } from "../../Typings/viewModels/UserViewModel";
import { DiaryViewModel } from "../../Typings/viewModels/DiaryViewModel";
import DiariesStore from "../../stores/DiariesStore";

class StudentDiaryProps {
    diariesStore: DiariesStore;
    student: UserViewModel;
}

@observer
class StudentDiary extends Component<StudentDiaryProps> {
    diary: DiaryViewModel = new DiaryViewModel();
    
    constructor(props: StudentDiaryProps) {
        super(props);
        this.setDiary();
    }

    setDiary() {
        
    }
    
    renderApproveButton() {
        return (
            <div className="row justify-content-center">
                <Button
                    color="success"
                    onClick={() => this.approve()}>
                    Одобрить
                </Button>
            </div>
        );
    }

    renderDiary(student: UserViewModel) {
        return (
            <Diary
                diariesStore={this.props.diariesStore} 
                studentId={student.id}
            />
        );
    }
    
    render() {
        return (
            <>
                {this.renderDiary(this.props.student)}
                {this.renderApproveButton()}
            </>
        );
    }

    approve() {
        return (
            <></>
        );
    }
}

export default StudentDiary;