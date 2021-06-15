import React, { Component } from "react";
import { UserViewModel } from "../../../Typings/viewModels/UserViewModel";
import { observer } from "mobx-react";
import { Modal } from "reactstrap";
import StudentDiary from "../StudentDiary";
import { RootStore } from "../../../stores/RootStore";
import CommentGroup from "../../Common/Comments/CommentGroup";
import { CommentedEntityType } from "../../../Typings/enums/CommentedEntityType";
import { makeObservable, observable } from "mobx";

class StudentWindowProps {
    student: UserViewModel;
    toggle: any;
    store: RootStore;
}

@observer
class StudentWindow extends Component<StudentWindowProps> {
    chatOpen: boolean;
    
    constructor(props: StudentWindowProps) {
        super(props);
        makeObservable(this, {
            chatOpen: observable
        });
    }

    renderStudentDiary() {
        return (
            <StudentDiary
                diariesStore={this.props.store.diariesStore} 
                student={this.props.student} />
        );
    }

    renderChat() {
        if(this.chatOpen) {
            return (
                <CommentGroup
                    commentedEntityId={1} commentedEntityType={CommentedEntityType.Diary}
                    onToggle={this.chatToggle} store={this.props.store} userId={this.props.student.id}
                />
            )
        } else {
            return (
                <i
                    onClick={() => this.chatToggle()}
                    className="fa fa-comment fa-2x" />
            );
        }
    }
    
    renderStudentWindow(student: UserViewModel) {
        return (
            <Modal isOpen={true} onClick={() => this.props.toggle()}>
                <i style={{marginLeft: '96%', width: '2%'}}
                   onClick={() => this.props.toggle()}/>
                <div className="row justify-content-center">
                    <span>{student.fio}</span>
                </div>
                <div className="row justify-content-center">
                    <div className="col-lg-9 col-md-9 col-sm-12 col-xs-12">
                        {this.renderStudentDiary()}
                    </div>
                    <div className="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        {this.renderChat()}
                    </div>
                </div>
            </Modal>
        )
    }
    render() {
        return (
            <>
                {this.renderStudentWindow(this.props.student)}
            </>
        );
    }

    chatToggle = () => {
        this.chatOpen = !this.chatOpen;
    }
}

export default StudentWindow;