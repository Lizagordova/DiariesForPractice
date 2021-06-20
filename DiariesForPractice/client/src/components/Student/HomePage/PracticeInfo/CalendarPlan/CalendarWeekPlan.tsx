import React, {Component} from "react";
import {observer} from "mobx-react";
import {makeObservable, observable, toJS} from "mobx";
import {CalendarWeekPlanViewModel} from "../../../../../Typings/viewModels/CalendarWeekPlanViewModel";
import {Input, Label} from "reactstrap";
import {ToggleType} from "../../../../../consts/ToggleType";

class CalendarWeekPlanProps {
    calendarWeekPlan: CalendarWeekPlanViewModel;
    updateCalendarPlan: any;
    index: number;
}

@observer
class CalendarWeekPlan extends Component<CalendarWeekPlanProps> {
    calendarWeekPlan: CalendarWeekPlanViewModel = new CalendarWeekPlanViewModel();
    edit: boolean;
    
    constructor(props: CalendarWeekPlanProps) {
        super(props);
        makeObservable(this, {
            calendarWeekPlan: observable,
            edit: observable,
        });
    }
    
    setCalendarWeekPlan() {
        this.calendarWeekPlan = this.props.calendarWeekPlan;
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

    renderNameOfTheTypesWork(name: string) {
        return (
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">Тип работы:</Label>
                </div>
                <div className="col-lg-9 col-md-9 col-sm-12">
                    <Input
                        onInput={() => this.editToggle(ToggleType.on)}
                        className="studentInfoInput"
                        value={name}
                        onChange={(event) => this.inputChange(event)}/>
                </div>
            </>
        );
    }
    
    render() {
        return (
            <div className="calendarPlan">
                <div className="row justify-content-center studentInfoBlock">
                    {this.renderNameOfTheTypesWork(this.calendarWeekPlan.nameOfTheWork)}
                </div>
            </div>
        );
    }

    inputChange(event: React.ChangeEvent<HTMLInputElement>) {
        this.calendarWeekPlan.nameOfTheWork = event.currentTarget.value;
        this.props.updateCalendarPlan(this.calendarWeekPlan, this.props.index);
    }

    editToggle(type: ToggleType) {
        this.edit = type === ToggleType.on;
    }
    
}

export default CalendarWeekPlan;