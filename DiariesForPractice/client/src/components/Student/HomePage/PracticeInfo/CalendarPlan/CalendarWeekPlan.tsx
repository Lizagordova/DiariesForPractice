import React, {Component} from "react";
import {observer} from "mobx-react";
import {makeObservable, observable} from "mobx";
import {CalendarWeekPlanViewModel} from "../../../../../Typings/viewModels/CalendarWeekPlanViewModel";
import {Input, Label} from "reactstrap";
import {ToggleType} from "../../../../../consts/ToggleType";
import Calendar from "react-calendar";
import {DateType} from "../../../../../consts/DateType";

class CalendarWeekPlanProps {
    calendarWeekPlan: CalendarWeekPlanViewModel;
    updateCalendarPlan: any;
    index: number;
}

@observer
class CalendarWeekPlan extends Component<CalendarWeekPlanProps> {
    calendarWeekPlan: CalendarWeekPlanViewModel = new CalendarWeekPlanViewModel();
    edit: boolean;
    startDateOpen: boolean;
    endDateOpen: boolean;
    
    constructor(props: CalendarWeekPlanProps) {
        super(props);
        makeObservable(this, {
            calendarWeekPlan: observable,
            edit: observable,
            startDateOpen: observable,
            endDateOpen: observable,
        });
    }
    
    componentDidUpdate(prevProps: Readonly<CalendarWeekPlanProps>, prevState: Readonly<{}>, snapshot?: any) {
        this.setCalendarWeekPlan();
    }

    setCalendarWeekPlan() {
        this.calendarWeekPlan = this.props.calendarWeekPlan;
    }
    
    renderWorkingPeriod() {
        return (
            <></>
        );
    }
    
    renderStartDate(date: Date) {
        return (
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">Начало практики:</Label>
                </div>
                <div className="col-lg-9 col-md-9 col-sm-12">
                    <div className="row justify-content-center">
                        <i className="fa fa-calendar fa-2x" onClick={() => this.toggle(PracticeDetailsToggleType.StartDate)}/>
                        {this.startDateOpen &&  <Calendar
                            value={date}
                            onChange={(date) => this.inputDate(date, DateType.StartDate)}
                        />}
                    </div>
                </div>
            </>
        );
    }

    renderEndDate(date: Date) {
        return (
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">Окончание практики:</Label>
                </div>
                <div className="col-lg-9 col-md-9 col-sm-12">
                    <div className="row justify-content-center">
                        <i className="fa fa-calendar fa-2x" onClick={() => this.toggle(PracticeDetailsToggleType.EndDate)}/>
                        {this.endDateOpen &&  <Calendar
                            value={date}
                            onChange={(date) => this.inputDate(date, DateType.EndDate)}
                        />}
                    </div>
                </div>
            </>
        );
    }

    renderNameOfTheTypesWork(name: string) {
        if(name === null || name === undefined) {
            name = "";
        }
        console.log("name", name);
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
                        defaultValue={name}
                        onChange={(event) => this.inputChange(event)}/>
                </div>
            </>
        );
    }
    
    render() {
        console.log("calendarWeekPlan", this.calendarWeekPlan);
        return (
            <div className="calendarPlanWeek">
                <div className="row justify-content-center studentInfoBlock">
                    {this.renderNameOfTheTypesWork(this.calendarWeekPlan.nameOfTheWork)}
                </div>
                <div className="row justify-content-center studentInfoBlock">
                    {this.renderStartDate(this.calendarWeekPlan.startDate)}
                </div>
                <div className="row justify-content-center studentInfoBlock">
                    {this.renderEndDate(this.calendarWeekPlan.endDate)}
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

    toggle(type: PracticeDetailsToggleType) {
        if(type === PracticeDetailsToggleType.Edit) {
            this.edit = !this.edit;
        } else if(type === PracticeDetailsToggleType.StartDate) {
            this.startDateOpen = !this.startDateOpen;
        } else if(type === PracticeDetailsToggleType.EndDate) {
            this.endDateOpen = !this.endDateOpen;
        }
    }

    inputDate(date: Date | Date[], type: DateType) {
        if(type === DateType.StartDate) {
            this.calendarWeekPlan.startDate = date;
        } else if(type === DateType.EndDate) {
            this.calendarWeekPlan.endDate = date;
        }
    }
}

export default CalendarWeekPlan;

enum PracticeDetailsToggleType {
    Update,
    StartDate,
    EndDate,
    Edit
}