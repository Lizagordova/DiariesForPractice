﻿import React, { Component } from "react";
import { observer } from "mobx-react";
import { StudentTaskViewModel } from "../../../../Typings/viewModels/StudentTaskViewModel";
import { makeObservable, observable } from "mobx";
import PracticeStore from "../../../../stores/PracticeStore";
import { Button, Alert, Input, Label } from "reactstrap";
import { mapToStudentTaskReadModel } from "../../../../functions/mapper";
import {ProgressBar} from "react-bootstrap";
import {WarningType} from "../../../../consts/WarningType";
import {warningTypeRenderer} from "../../../../functions/warningTypeRenderer";

class StudentTaskProps {
    practiceStore: PracticeStore;
    studentTask: StudentTaskViewModel;
    practiceDetailsId: number;
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
        this.studentTask = this.props.studentTask;
    }
    
    renderStudentTask(task: string) {
        return (
            <>
                {!this.edit && <span>{task}</span>}
                {this.edit && <>
                    <Label>Задание</Label>
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
                {this.saved && warningTypeRenderer(WarningType.Saved)}
                {this.notSaved && warningTypeRenderer(WarningType.NotSaved)}
            </>
        );
    }

    renderSaveButton(edit: boolean) {
        return (
            <Button
                className="authButton"
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
                <Label>Индивидуальное задание</Label>
                {!this.edit && <i className="fa fa-edit fa-2x" onClick={() =>  this.editToggle()} />}
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
        let studentTask = mapToStudentTaskReadModel(this.studentTask, this.props.practiceDetailsId);
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