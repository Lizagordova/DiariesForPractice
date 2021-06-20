import React, {Component} from "react";
import {observer} from "mobx-react";
import {StudentTaskViewModel} from "../../../../Typings/viewModels/StudentTaskViewModel";
import {makeObservable, observable, toJS} from "mobx";
import PracticeStore from "../../../../stores/PracticeStore";
import {Button, Input, Label} from "reactstrap";
import {mapToStudentTaskReadModel} from "../../../../functions/mapper";
import {ProgressBar} from "react-bootstrap";
import {WarningType} from "../../../../consts/WarningType";
import {warningTypeRenderer} from "../../../../functions/warningTypeRenderer";
import {ToggleType} from "../../../../consts/ToggleType";
import {renderProgress} from "../../../../functions/progress";

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
    progress: HTMLDivElement | null;
    
    constructor(props: StudentTaskProps) {
        super(props);
        makeObservable(this, {
            studentTask: observable,
            edit: observable,
            notSaved: observable,
            saved: observable,
            progress: observable,
        });
        this.setStudentTask();
    }

    setStudentTask() {
        this.studentTask = this.props.studentTask;
    }
    
    componentDidMount() {
        this.updateProgress();
    }

    renderStudentTask(task: string) {
        return (
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">Задание:</Label>
                </div>
                <div className="col-lg-9 col-md-9 col-sm-12">
                    <Input
                        onInput={() => this.editToggle(ToggleType.on)}
                        className="studentInfoInput"
                        value={task}
                        onChange={(event) => this.changeStudentTask(event)}/>
                </div>
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

    renderProgress() {
        return (
            <div id="prog-bar" className="progress">
                <div id="progress-bar" className="progress-bar" ref={c => this.progress = c}>
                </div>
            </div>
        );
    }

    updateProgress() {
        let progressPercentage = this.computeProgress();
        let progress = this.progress;
        if(progress !== null && progress !== undefined) {
            progress.style.width = progressPercentage.toString() + "%";
        }
        this.progress = progress;
    }
    
    renderHeader(edit: boolean) {
        return (
            <>
                <Label className="studentInfoTitleLabel">Индивидуальное задание</Label>
                {edit && <i className="fa fa-save fa-2x icon" onClick={() => this.save()}/>}
                {edit && <i className="fa fa-window-close fa-2x icon" onClick={() => this.editToggle(ToggleType.off)} />}
            </>
        );
    }
    
    render() {
        return (
            <>
                {this.renderWarnings()}
                <div className="row justify-content-center">
                    {this.renderHeader(this.edit)}
                </div>
                <div className="row justify-content-center studentInfoBlock">
                    {this.renderProgress()}
                </div>
                <div className="row justify-content-center studentInfoBlock">
                    {this.renderStudentTask(this.studentTask.task)}
                </div>
            </>
        );
    }

    editToggle(type: ToggleType) {
        this.edit = type === ToggleType.on;
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
        console.log("this studentTask", toJS(this.studentTask));
        if(this.studentTask.task !== "") {
            progress = 100;
        }
        console.log(progress);
        return progress;
    }
}

export default IndividualTask;