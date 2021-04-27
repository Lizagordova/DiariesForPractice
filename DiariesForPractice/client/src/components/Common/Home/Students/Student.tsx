import React, { Component } from 'react';
import { RootStore } from "../../../../stores/RootStore";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import { StudentViewModel } from "../../../../Typings/viewModels/StudentViewModel";
import { DiaryViewModel } from "../../../../Typings/viewModels/DiaryViewModel";
import {Label, Button, Alert} from "reactstrap";

class IStudentProps {
    studentId: number;
    store: RootStore;
}

@observer
class Student extends Component<IStudentProps> {
    student: StudentViewModel = new StudentViewModel();
    diary: DiaryViewModel = new DiaryViewModel();

    constructor(props: IStudentProps) {
        super(props);
        makeObservable(this, {
            student: observable,
            diary: observable
        });
        this.setInitialState();
    }

    setInitialState() {
        this.student = this.props.store.studentStore.students.filter(s => s.id === this.props.studentId)[0];
        this.diary = this.props.store.diariesStore.diaries.filter(s => s.userId === this.props.studentId)[0];
    }

    renderGeneratedOption() {
        if(this.diary.generated) {
            return (
                <Label>Сгенерирован</Label>
            );
        } else {
            return (
                <>
                    <Label>Не сгерерирован</Label>
                    <Button
                        outline
                        style={{borderColor: "black"}}
                        onClick={() => this.generate()}>
                        Сгенерировать
                    </Button>
                </>
            );
        }
    }

    renderSendOption() {
        if(this.diary.send) {
            return (
                <Label>Отправлен</Label>
            );
        } else {
            return (
                <>
                    <Label>Не отправлен</Label>
                    <Button
                        outline
                        style={{borderColor: "black"}}
                        onClick={() => this.props.store.diariesStore.sendDiary(this.props.studentId)}>
                        Отправить
                    </Button>
                </>
            );
        }
    }

    renderDiaryDetails() {
        return (
            <>
                {this.renderGeneratedOption()}
                {this.renderSendOption()}
            </>
        );
    }

    renderPreviewWindow() {
        if(!this.diary.generated) {
            return (
                <Alert color="primary">Просмотр невозможен, так как дневник ещё не сгенерирован</Alert>
            );
        } else {
            return(
                <iframe src={this.diary.path}/>
            );
        }
    }

    renderStudentDetails() {
        return (
            <div className="row justify-content-center">
                <div className="col-lg-2">
                    {this.renderDiaryDetails()}
                </div>
                <div className="col-lg-10">
                    {this.renderPreviewWindow()}
                </div>
            </div>
        );
    }

    render() {
        return (
            <div className="container-fluid">
                {this.renderStudentDetails()}
            </div>
        );
    }

    generate() {
        this.props.store.diariesStore.generateDiary(this.props.studentId)
            .then(() => {
                
            })
    }
}

export default Student;