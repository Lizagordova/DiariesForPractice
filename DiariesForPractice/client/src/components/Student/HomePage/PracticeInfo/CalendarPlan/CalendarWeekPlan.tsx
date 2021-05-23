import React, { Component } from "react";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import { CalendarWeekPlanViewModel } from "../../../../../Typings/viewModels/CalendarWeekPlanViewModel";

class CalendarWeekPlanProps {
    calendarWeekPlan: CalendarWeekPlanViewModel;
    updateCalendarPlanWeek: any;
}

@observer
class CalendarWeekPlan extends Component<CalendarWeekPlanProps> {
    calendarWeekPlan: CalendarWeekPlanViewModel = new CalendarWeekPlanViewModel();
    
    constructor(props: CalendarWeekPlanProps) {
        super(props);
        makeObservable(this, {
            calendarWeekPlan: observable
        });
    }
    
    renderWorkingPeriod() {
        return (
            <></>
        );
    }
    
    renderStartDate() {
        return (
            <></>
        );
    }

    renderEndDate() {
        return (
            <></>
        );
    }

    renderNameOfTheTypesWork() {
        return (
            <></>
        );
    }
    
    render() {
        return (
            <></>
        );
    }
}

export default CalendarWeekPlan;