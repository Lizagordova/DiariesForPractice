import React, {Component} from "react";
import {observer} from "mobx-react";
import {makeObservable, observable, toJS} from "mobx";
import {CalendarPlanViewModel} from "../../../../../Typings/viewModels/CalendarPlanViewModel";
import {Button, Label} from "reactstrap";
import {CalendarWeekPlanViewModel} from "../../../../../Typings/viewModels/CalendarWeekPlanViewModel";
import CalendarWeekPlan from "./CalendarWeekPlan";
import PracticeStore from "../../../../../stores/PracticeStore";
import {mapToCalendarPlanReadModel} from "../../../../../functions/mapper";
import {WarningType} from "../../../../../consts/WarningType";
import {warningTypeRenderer} from "../../../../../functions/warningTypeRenderer";
import {ToggleType} from "../../../../../consts/ToggleType";

class CalendarPlanProps {
    practiceStore: PracticeStore;
    calendarPlan: CalendarPlanViewModel;
    practiceDetailsId: number;
}

@observer
class CalendarPlan extends Component<CalendarPlanProps> {
    calendarPlan: CalendarPlanViewModel = new CalendarPlanViewModel();
    edit: boolean;
    saved: boolean;
    notSaved: boolean;
    progress: HTMLDivElement | null;
    update: boolean;

    constructor(props: CalendarPlanProps) {
        super(props);
        makeObservable(this, {
            calendarPlan: observable,
            edit: observable,
            saved: observable,
            notSaved: observable,
            progress: observable,
            update: observable
        });
        this.setCalendarPlan();
    }

    componentDidMount() {
        this.updateProgress();
    }
    
    setCalendarPlan() {
        this.calendarPlan = this.props.calendarPlan;
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
        let progressPercentage = this.computeProgress(this.calendarPlan);
        let progress = this.progress;
        if(progress !== null && progress !== undefined) {
            progress.style.width = progressPercentage.toString() + "%";
        }
        this.progress = progress;
    }

    renderAddButton() {
        return (
            <i 
                className="fa fa-plus fa-3x"
               onClick={() => this.addCalendarWeekPlan()}
            />
        );
    }
    
    renderCalendarWeekPlans(calendarWeekPlans: CalendarWeekPlanViewModel[], update: boolean) {
        console.log("calendarWeekPlans", calendarWeekPlans);
        return (
            <>
                {calendarWeekPlans.map((plan, index) => {
                    return (
                        <CalendarWeekPlan
                            key={index}
                            calendarWeekPlan={plan}
                            index={index} updateCalendarPlan={this.updateCalendarPlanWeek}/>
                    );
                })}
            </>
        );
    }

    renderHeader(edit: boolean) {
        return(
            <>
                <Label className="studentInfoTitleLabel">Календарный план</Label>
                {edit && <i className="fa fa-save fa-2x icon" onClick={() => this.save()}/>}
                {edit && <i className="fa fa-window-close fa-2x icon" onClick={() => this.editToggle(ToggleType.off)} />}
            </>
        );
    }
    
    render() {
        console.log("calendarPa", toJS(this.calendarPlan));
        return (
            <>
                {this.renderWarnings()}
                <div className="row justify-content-center">
                    {this.renderHeader(this.edit)}
                </div>
                <div className="row justify-content-center">
                    {this.renderProgress()}
                </div>
                <div className="row justify-content-center">
                    <div className="container-fluid">
                        {this.renderCalendarWeekPlans(this.calendarPlan.calendarWeekPlans, this.update)}
                    </div>
                </div>
                <div className="row justify-content-center">
                    {this.renderAddButton()}
                </div>
            </>
        );
    }

    computeProgress(calendarPlan: CalendarPlanViewModel): number {
        let progress = 0;
        if(calendarPlan.calendarWeekPlans.length > 0) {
            progress = 100;
        }

        return progress;
    }

    editToggle(type: ToggleType) {
        this.edit = type === ToggleType.on;
    }

    save() {
        let calendarPlan = mapToCalendarPlanReadModel(this.calendarPlan, this.props.practiceDetailsId);
        this.props.practiceStore
            .addOrUpdateCalendarPlan(calendarPlan)
            .then((status) => {
                this.saved = status === 200;
                this.notSaved = status !== 200;
                this.edit = status === 200;
            });
    }

    addCalendarWeekPlan() {
        let calendarWeekPlan = new CalendarWeekPlanViewModel();
        this.calendarPlan.calendarWeekPlans.push(calendarWeekPlan);
        this.updateToggle();
    }

    updateCalendarPlanWeek = (calendarWeekPlan: CalendarWeekPlanViewModel, index: number) => {
        this.calendarPlan.calendarWeekPlans[index] = calendarWeekPlan;
    }

    updateToggle() {
        this.update = !this.update;
    }
}

export default CalendarPlan;