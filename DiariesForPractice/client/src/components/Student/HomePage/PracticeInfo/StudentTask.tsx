import React, { Component } from "react";
import { observer } from "mobx-react";
import { StudentTaskViewModel } from "../../../../Typings/viewModels/StudentTaskViewModel";
import { makeObservable, observable } from "mobx";
import PracticeStore from "../../../../stores/PracticeStore";
import { Button, Alert, Input, Label } from "reactstrap";
import { mapToStudentTaskReadModel } from "../../../../functions/mapper";
import {ProgressBar} from "react-bootstrap";

class StudentTaskProps {
    practiceStore: PracticeStore;
    studentId: number;
}

@observer
class IndividualTask extends Component<StudentTaskProps> {
    studentTask: StudentTaskViewModel = new StudentTaskViewModel();
    edit: boolean;
    notSaved: boolean;
    saved: boolean;
    
    constructor(props: StudentTaskProps) {
        super(props);
        makeObservable(this, {
            studentTask: observable,
            edit: observable,
            notSaved: observable,
            saved: observable,
        });
        this.setStudentTask();
    }

    setStudentTask() {
        let studentId = this.props.studentId;
        this.props.practiceStore.getStudentTask(studentId)
            .then((studentTask) => {
                this.studentTask = studentTask;
            });
    }
    
    renderStudentTask(task: string) {
        return (
            <>
                {!this.edit && <span>{task}</span>}
                {this.edit && <>
                    <Label>Индивидуальное задание</Label>
                    <Input
                    value={task}
                    placeholder="Индивидуальное задание"
                    onChange={(event) => this.changeStudentTask(event)} />
                    </>}
            </>
        )
    }
    
    renderWarnings() {
        setTimeout(() => {
            this.notSaved = false;
            this.saved = false;
        }, 6000)
        return (
            <>
                <Alert color="success">Данные успешно обновлены!</Alert>
                <Alert color="danger">Что-то пошло не так и данные не обновились!</Alert>
            </>
        );
    }

    renderSaveButton(edit: boolean) {
        return (
            <Button
                outline color="primary"
                onClick={() => this.save()}>
                Сохранить
            </Button>
        );
    }

    renderSectionProgress() {
        let progress = this.computeProgress();
        return (
            <ProgressBar>{progress}</ProgressBar>
        );
    }
    
    renderHeader() {
        return (
            <>
                <Label>
                    Индивидуальное задание
                </Label>
                {!this.edit && <i className="fas fa-edit fa-2x" onClick={() =>  this.editToggle()} />}
                {this.renderSectionProgress()}
            </>
        );
    }
    
    render() {
        return (
            <>
                {this.renderWarnings()}
                <div className="row justify-content-center">
                    {this.renderHeader()}
                </div>
                <div className="row justify-content-center">
                    {this.renderStudentTask(this.studentTask.task)}
                </div>
                {this.edit && <div className="row justify-content-center">
                    {this.renderSaveButton(this.edit)}
                </div>}
            </>
        );
    }

    editToggle() {
        this.edit = !this.edit;
    }

    changeStudentTask(event: React.ChangeEvent<HTMLInputElement>) {
        this.studentTask.task = event.currentTarget.value;
    }
    
    save() {
        let studentTask = mapToStudentTaskReadModel(this.studentTask);
        this.props.practiceStore
            .addOrUpdateStudentTask(studentTask)
            .then((status) => {
                this.notSaved = status !== 200;
                this.saved = status === 200;
            });     
    }

    computeProgress(): number {
        let progress = 0;
        if(this.studentTask.task !== "") {
            progress = 100;
        }
        
        return progress;
    }
}

export default IndividualTask;