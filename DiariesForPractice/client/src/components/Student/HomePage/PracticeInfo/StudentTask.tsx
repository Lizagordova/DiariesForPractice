import React, { Component } from "react";
import { observer } from "mobx-react";
import { StudentTaskViewModel } from "../../../../Typings/viewModels/StudentTaskViewModel";
import { makeObservable, observable } from "mobx";
import PracticeStore from "../../../../stores/PracticeStore";
import { Button, Alert, Input } from "reactstrap";
import { mapToStudentTaskReadModel } from "../../../../functions/mapper";

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
                {this.edit && <Input//todo: добавить label
                    value={task}
                    placeholder="Индивидуальное задание"
                    onChange={(event) => this.changeStudentTask(event)} />}
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
    
    renderButton(edit: boolean) {
        if(edit) {
            return (
                <Button
                    outline color="primary"
                    onClick={() => this.save()}>
                    Сохранить
                </Button>
            );
        } else {
            return (
                <Button
                    outline color="primary"
                    onClick={() => this.editToggle()}>
                    Редактировать
                </Button>
            );
        }
    }
    
    render() {
        return (
            <>
                {this.renderWarnings()}
                <div className="row justify-content-center">
                    {this.renderStudentTask(this.studentTask.task)}
                </div>
                <div className="row justify-content-center">
                    {this.renderButton(this.edit)}
                </div>
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
}

export default IndividualTask;