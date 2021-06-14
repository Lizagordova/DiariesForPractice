import React, {Component} from "react";
import {observer} from "mobx-react";
import {makeObservable, observable} from "mobx";
import {PracticeViewModel} from "../../../../Typings/viewModels/PracticeViewModel";
import {Alert, Dropdown, DropdownItem, DropdownMenu, DropdownToggle, Input, Label} from "reactstrap";
import {ReportingForm} from "../../../../Typings/enums/ReportingForm";
import {translatePracticeType, translateReportingForm} from "../../../../functions/translater";
import {PracticeType} from "../../../../Typings/enums/PracticeType";
import Calendar from "react-calendar";
import PracticeStore from "../../../../stores/PracticeStore";
import { mapToPracticeDetailsReadModel} from "../../../../functions/mapper";
import {ProgressBar} from "react-bootstrap";
import {CalendarPlanViewModel} from "../../../../Typings/viewModels/CalendarPlanViewModel";
import CalendarPlan from "./CalendarPlan/CalendarPlan";

class PracticeDetailsInfoProps {
    practiceStore: PracticeStore;
    practiceDetails: PracticeViewModel;
}

@observer
class PracticeDetailsInfo extends Component<PracticeDetailsInfoProps> {
    practiceDetails: PracticeViewModel = new PracticeViewModel();
    edit: boolean;
    reportingFormOpen: boolean;
    update: boolean;
    practiceTypeOpen: boolean;
    startDateOpen: boolean;
    endDateOpen: boolean;
    saved: boolean;
    notSaved: boolean;
    
    constructor(props: PracticeDetailsInfoProps) {
        super(props);
        makeObservable(this, {
            practiceDetails: observable,
            edit: observable,
            reportingFormOpen: observable,
            update: observable,
            practiceTypeOpen: observable,
            startDateOpen: observable,
            endDateOpen: observable,
            saved: observable,
            notSaved: observable
        });
        this.setPracticeDetails();
    }

    setPracticeDetails() {
        this.practiceDetails = this.props.practiceDetails;
    }
    
    renderWarnings() {
        setTimeout(() => {
            this.saved = false;
            this.notSaved = false;
        }, 6000);
        return (
            <>
                {this.saved && <Alert>Данные успешно сохранились!</Alert>}
                {this.notSaved && <Alert>Что-то пошло не так и данные не сохранились.</Alert>}
            </>
        );
    }

    renderReportingForm(reportingForm: ReportingForm) {
        return(
            <Dropdown isOpen={this.reportingFormOpen} toggle={() => this.toggle(ToggleType.ReportingForm)}>
                <DropdownToggle caret>
                    {translateReportingForm(reportingForm)}
                </DropdownToggle>
                <DropdownMenu>
                    <DropdownItem
                        key={1}
                        onClick={() => this.chooseReportingForm(ReportingForm.Spravka)}>
                        {translateReportingForm(ReportingForm.Spravka)}
                    </DropdownItem>
                    <DropdownItem
                        key={2}
                        onClick={() => this.chooseReportingForm(ReportingForm.Dogovor)}>
                        {translateReportingForm(ReportingForm.Dogovor)}
                    </DropdownItem>
                </DropdownMenu>
            </Dropdown>
        );
    }

    renderContractNumber(contractNumber: string, edit: boolean) {
        return(
            <>
                <Label>Номер договора: </Label>
                {edit && <span>{contractNumber}</span>}
                {!edit && <Input
                    placeholder="Номер договора"
                    value={this.practiceDetails.contractNumber}
                    onChange={(event) => this.changePracticeDetails(event, PracticeDetailsType.ContractNumber)}>
                    {this.practiceDetails.contractNumber}
                </Input>}
            </>
        );
    }

    renderPracticeType(practiceType: PracticeType) {
        return (
            <Dropdown isOpen={this.practiceTypeOpen} toggle={() => this.toggle(ToggleType.ReportingForm)}>
                <DropdownToggle caret>
                    {translatePracticeType(practiceType)}
                </DropdownToggle>
                <DropdownMenu>
                    <DropdownItem
                        key={1}
                        onClick={() => this.chooseReportingForm(ReportingForm.Spravka)}>
                        {translateReportingForm(ReportingForm.Spravka)}
                    </DropdownItem>
                    <DropdownItem
                        key={2}
                        onClick={() => this.chooseReportingForm(ReportingForm.Dogovor)}>
                        {translateReportingForm(ReportingForm.Dogovor)}
                    </DropdownItem>
                </DropdownMenu>
            </Dropdown>
        );
    }

    renderStartDate(date: Date) {
        return (
            <>
                <Label>Начало практики:</Label>
                <i className="far fa-calendar-alt" onClick={() => this.toggle(ToggleType.StartDate)}/>
                {this.startDateOpen &&  <Calendar
                    value={date}
                    onChange={(date) => this.inputDate(date, DateType.StartDate)}
                />}
            </>
        );
    }
    
    renderEndDate(date: Date) {
        return (
            <>
                <Label>Окончание практики:</Label>
                <i className="far fa-calendar-alt" onClick={() => this.toggle(ToggleType.EndDate)}/>
                {this.startDateOpen &&  <Calendar
                    value={date}
                    onChange={(date) => this.inputDate(date, DateType.EndDate)}
                />}
            </>
        );
    }

    renderStructuralDivision(structuralDivision: string, edit: boolean) {
        return (
            <>
                <Label>Структурное подразделение:</Label>
                {!edit && <span>{structuralDivision}</span>}
                {edit && <Input
                    placeholder="Структурное подразделение"
                    value={structuralDivision}
                    onChange={(event) => this.changePracticeDetails(event, PracticeDetailsType.StructuralDivision)}
                />}
            </>
        );
    }

    renderOrderOfPassingPractice() {
        return (
            <></>
        );
    }
    
    renderSectionProgress() {
        let progress = this.computeProgress(this.practiceDetails)
        return (
            <ProgressBar>
                {progress}
            </ProgressBar>
        );
    }
    
    renderHeader() {
        return (
            <>
                <Label>Детали практики</Label>
                {!this.edit && <i className="fas fa-edit fa-2x" onClick={() =>  this.toggle(ToggleType.Edit)} />}
                {this.renderSectionProgress()}
            </>
        );
    }

    renderCalendarPlan(calendarPlan: CalendarPlanViewModel) {
        return (
            <CalendarPlan
                calendarPlan={calendarPlan} practiceDetailsId={this.practiceDetails.id}
                practiceStore={this.props.practiceStore}
            />
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
                    {this.renderReportingForm(this.practiceDetails.reportingForm)}
                </div>
                <div className="row justify-content-center">
                    {this.renderContractNumber(this.practiceDetails.contractNumber, this.edit)}
                </div>
                <div className="row justify-content-center">
                    {this.renderPracticeType(this.practiceDetails.practiceType)}
                </div>
                <div className="row justify-content-center">
                    {this.renderStartDate(this.practiceDetails.startDate)}
                </div>
                <div className="row justify-content-center">
                    {this.renderEndDate(this.practiceDetails.endDate)}
                </div>
                <div className="row justify-content-center">
                    {this.renderStructuralDivision(this.practiceDetails.structuralDivision, this.edit)}
                </div>
                <div className="row justify-content-center">
                    {this.renderCalendarPlan(this.practiceDetails.calendarPlan)}
                </div>
                <div className="row justify-content-center">
                    {this.renderOrderOfPassingPractice()}
                </div>
            </>
        );
    }

    chooseReportingForm(reportingForm: ReportingForm) {
        this.practiceDetails.reportingForm = reportingForm;
        this.toggle(ToggleType.Update);
    }
    
    toggle(type: ToggleType) {
        if(type === ToggleType.Update) {
            this.update = !this.update;
        } else if(type === ToggleType.ReportingForm) {
            this.reportingFormOpen = !this.reportingFormOpen;
        } else if(type === ToggleType.PracticeType) {
            this.practiceTypeOpen = !this.practiceTypeOpen;
        } else if(type === ToggleType.StartDate) {
            this.startDateOpen = !this.startDateOpen;
        } else if(type === ToggleType.EndDate) {
            this.endDateOpen = !this.endDateOpen;
        }
    }

    changePracticeDetails(event: React.ChangeEvent<HTMLInputElement>, type: PracticeDetailsType) {
        let value = event.currentTarget.value;
        if(type === PracticeDetailsType.ContractNumber) {
            this.practiceDetails.contractNumber = value;
        } else if(type === PracticeDetailsType.StructuralDivision) {
            this.practiceDetails.structuralDivision = value;
        }
    }

    inputDate(date: Date | Date[], type: DateType) {
        if(type === DateType.StartDate) {
            this.practiceDetails.startDate = date;
        } else if(type === DateType.EndDate) {
            this.practiceDetails.endDate = date;
        }
    }
    
    save() {
        let practiceDetails = mapToPracticeDetailsReadModel(this.practiceDetails);
        this.props.practiceStore
            .addOrUpdatePracticeDetails(practiceDetails)
            .then((status) => {
                this.saved = status === 200;
                this.notSaved = status !== 200;
            });
    }

    computeProgress(practiceDetails: PracticeViewModel) {//todo: 
        let progress = 0;
        if(practiceDetails.reportingForm !== ReportingForm.None) {
            progress += 20;
        }
        if(practiceDetails.structuralDivision !== "") {
            progress += 20;
        }
        if(practiceDetails.contractNumber !== "") {
            progress += 20;
        }
       
        return progress;
    }
    
    updateCalendarPlan(calendarPlan: CalendarPlanViewModel) {
        this.practiceDetails.calendarPlan = calendarPlan;
    }
}

export default PracticeDetailsInfo;

enum ToggleType {
    ReportingForm,
    Update,
    PracticeType,
    StartDate,
    EndDate,
    Edit
}

enum PracticeDetailsType {
    StructuralDivision,
    ContractNumber    
}

enum DateType {
    StartDate,
    EndDate
}