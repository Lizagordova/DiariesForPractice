﻿import React, { Component } from "react";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import { CalendarPlanViewModel } from "../../../../../Typings/viewModels/CalendarPlanViewModel";
import {Label, Button, Alert} from "reactstrap";
import { ProgressBar } from "react-bootstrap";
import { CalendarWeekPlanViewModel } from "../../../../../Typings/viewModels/CalendarWeekPlanViewModel";
import CalendarWeekPlan from "./CalendarWeekPlan";
import PracticeStore from "../../../../../stores/PracticeStore";
import { mapToCalendarPlanReadModel } from "../../../../../functions/mapper";
import { WarningType } from "../../../../../consts/WarningType";
import { warningTypeRenderer } from "../../../../../functions/warningTypeRenderer";

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

    constructor(props: CalendarPlanProps) {
        super(props);
        makeObservable(this, {
            calendarPlan: observable,
            edit: observable,
            saved: observable,
            notSaved: observable,
        });
        this.setCalendarPlan();
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
    
    renderSectionProgress() {
        let progress = this.computeProgress(this.calendarPlan);
        return (
            <ProgressBar>
                {progress}
            </ProgressBar>
        );
    }

    renderAddButton() {
        return (
            <i 
                className="fa fa-plus fa-3x"
               onClick={() => this.addCalendarWeekPlan()}
            />
        );
    }
    
    renderCalendarWeekPlans(calendarWeekPlans: CalendarWeekPlanViewModel[]) {
        return (
            <>
                {calendarWeekPlans.map((plan) => {
                    return (
                        <CalendarWeekPlan
                            calendarWeekPlan={plan} updateCalendarPlanWeek={this.updateCalendarPlanWeek} />
                    );
                })}
                {this.renderAddButton()}
            </>
        );
    }

    renderHeader() {
        return(
            <>
                <Label>Календарный план</Label>
                {!this.edit && <i className="fa fa-edit fa-2x" onClick={() =>  this.editToggle()} />}
                {this.renderSectionProgress()}
            </>
        );
    }

    renderSaveButton() {
        return (
            <Button
                className="authButton"
                onClick={() => this.save()}>
                Сохранить
            </Button>
        );
    }
    
    render() {
        return (
            <>
                {this.renderWarnings()}
                <div className="row justify-content-center">
                    {this.renderHeader()}
                </div>
                {this.renderCalendarWeekPlans(this.calendarPlan.calendarWeekPlans)}
                {this.edit && <div className="row justify-content-center">
                    {this.renderSaveButton()}
                </div>}
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

    editToggle() {
        this.edit = !this.edit;
    }

    save() {
        //this.edit = false;
        let calendarPlan = mapToCalendarPlanReadModel(this.calendarPlan, this.props.practiceDetailsId);
        this.props.practiceStore
            .addOrUpdateCalendarPlan(calendarPlan)
            .then((status) => {
                this.saved = status === 200;
                this.notSaved = status !== 200;
            });
    }

    addCalendarWeekPlan() {
        let calendarWeekPlan = new CalendarWeekPlanViewModel();
        this.calendarPlan.calendarWeekPlans.push(calendarWeekPlan);
    }

    updateCalendarPlanWeek(calendarWeekPlan: CalendarWeekPlanViewModel, index: number) {
        this.calendarPlan.calendarWeekPlans[index] = calendarWeekPlan;
    }
}

export default CalendarPlan;