import React, {Component} from "react";
import {observer} from "mobx-react";
import {makeObservable, observable} from "mobx";
import {PracticeViewModel} from "../../../../Typings/viewModels/PracticeViewModel";
import {Alert, Dropdown, DropdownItem, DropdownMenu, DropdownToggle, Input, Label} from "reactstrap";
import {ReportingForm} from "../../../../Typings/enums/ReportingForm";
import {
    translatePracticeType,
    translateReportingForm
} from "../../../../functions/translater";
import {PracticeType} from "../../../../Typings/enums/PracticeType";
import Calendar from "react-calendar";
import PracticeStore from "../../../../stores/PracticeStore";
import { mapToPracticeDetailsReadModel} from "../../../../functions/mapper";
import {ProgressBar} from "react-bootstrap";
import {CalendarPlanViewModel} from "../../../../Typings/viewModels/CalendarPlanViewModel";
import {ToggleType} from "../../../../consts/ToggleType";
import {warningTypeRenderer} from "../../../../functions/warningTypeRenderer";
import {WarningType} from "../../../../consts/WarningType";

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
    progress: HTMLDivElement | null;
    
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
            notSaved: observable,
            progress: observable
        });
        this.setPracticeDetails();
    }

    setPracticeDetails() {
        this.practiceDetails = this.props.practiceDetails;
    }
    
    componentDidMount() {
        this.updateProgress();
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

    renderReportingForm(reportingForm: ReportingForm) {
        return(
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">Тип договора:</Label>
                </div>
                <div className="col-lg-9 col-md-9 col-sm-12">
                    <Dropdown isOpen={this.reportingFormOpen} toggle={() => this.toggle(PracticeDetailsToggleType.ReportingForm)} className="dropdown">
                        <DropdownToggle className="dropdownToggle" caret>
                            {translateReportingForm(reportingForm)}
                        </DropdownToggle>
                        <DropdownMenu className="dropdownMenu">
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
                </div>
            </>
        );
    }
    
    renderContractNumber(contractNumber: string) {
        return(
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">Номер договора:</Label>
                </div>
                <div className="col-lg-9 col-md-9 col-sm-12">
                    <Input
                        onInput={() => this.editToggle(ToggleType.on)}
                        className="studentInfoInput"
                        value={contractNumber}
                        onChange={(event) =>  this.changePracticeDetails(event, PracticeDetailsType.ContractNumber)} />
                </div>
            </>
        );
    }

    renderPracticeType(practiceType: PracticeType) {
        return (
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">Тип практики:</Label>
                </div>
                <div className="col-lg-9 col-md-9 col-sm-12">
                    <Dropdown isOpen={this.practiceTypeOpen} toggle={() => this.toggle(PracticeDetailsToggleType.PracticeType)} className="dropdown">
                        <DropdownToggle caret className="dropdownToggle">
                            {translatePracticeType(practiceType)}
                        </DropdownToggle>
                        <DropdownMenu className="dropdownMenu">
                            <DropdownItem
                                key={1}
                                onClick={() => this.choosePracticeType(PracticeType.Academic)}>
                                {translatePracticeType(PracticeType.Academic)}
                            </DropdownItem>
                            <DropdownItem
                                key={2}
                                onClick={() => this.choosePracticeType(PracticeType.Production)}>
                                {translatePracticeType(PracticeType.Production)}
                            </DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
                </div>
            </>
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
                        {this.startDateOpen &&  <Calendar
                            value={date}
                            onChange={(date) => this.inputDate(date, DateType.EndDate)}
                        />}
                    </div>
                </div>
            </>
        );
    }

    renderStructuralDivision(structuralDivision: string, edit: boolean) {
        return (
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">Структурное подразделение:</Label>
                </div>
                <div className="col-lg-9 col-md-9 col-sm-12">
                    <Input
                        onInput={() => this.editToggle(ToggleType.on)}
                        className="studentInfoInput"
                        value={structuralDivision}
                        onChange={(event) =>  this.changePracticeDetails(event, PracticeDetailsType.StructuralDivision)} />
                </div>
            </>
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
    
    renderHeader(edit: boolean) {
        return (
            <>
                <Label className="studentInfoTitleLabel">Детали практики</Label>
                {edit && <i className="fa fa-save fa-2x icon" onClick={() => this.save()}/>}
                {edit && <i className="fa fa-window-close fa-2x icon" onClick={() => this.editToggle(ToggleType.off)} />}
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
        let progressPercentage = this.computeProgress(this.practiceDetails);
        let progress = this.progress;
        if(progress !== null && progress !== undefined) {
            progress.style.width = progressPercentage.toString() + "%";
        }
        this.progress = progress;
    }
    
    render() {
        return (
            <>
                {this.renderWarnings()}
                <div className="row justify-content-center">
                    {this.renderHeader(this.edit)}
                </div>
                <div className="row studentInfoBlock blockWithDropdown">
                    {this.renderReportingForm(this.practiceDetails.reportingForm)}
                </div>
                <div className="row studentInfoBlock blockWithDropdown">
                    {this.renderContractNumber(this.practiceDetails.contractNumber)}
                </div>
                <div className="row studentInfoBlock blockWithDropdown">
                    {this.renderPracticeType(this.practiceDetails.practiceType)}
                </div>
                <div className="row studentInfoBlock blockWithDropdown">
                    {this.renderStartDate(this.practiceDetails.startDate)}
                </div>
                <div className="row studentInfoBlock blockWithDropdown">
                    {this.renderEndDate(this.practiceDetails.endDate)}
                </div>
                <div className="row studentInfoBlock blockWithDropdown">
                    {this.renderStructuralDivision(this.practiceDetails.structuralDivision, this.edit)}
                </div>
            </>
        );
    }

    chooseReportingForm(reportingForm: ReportingForm) {
        this.practiceDetails.reportingForm = reportingForm;
        this.toggle(PracticeDetailsToggleType.Update);
    }

    choosePracticeType(practiceType: PracticeType) {
        this.practiceDetails.practiceType = practiceType;
        this.toggle(PracticeDetailsToggleType.Update);
    }
    
    toggle(type: PracticeDetailsToggleType) {
        if(type === PracticeDetailsToggleType.Edit) {
            this.edit = !this.edit;
        } else if(type === PracticeDetailsToggleType.Update) {
            this.update = !this.update;
        } else if(type === PracticeDetailsToggleType.ReportingForm) {
            this.reportingFormOpen = !this.reportingFormOpen;
        } else if(type === PracticeDetailsToggleType.PracticeType) {
            this.practiceTypeOpen = !this.practiceTypeOpen;
        } else if(type === PracticeDetailsToggleType.StartDate) {
            this.startDateOpen = !this.startDateOpen;
        } else if(type === PracticeDetailsToggleType.EndDate) {
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
        this.updateProgress();
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

    editToggle(type: ToggleType) {
        this.edit = type === ToggleType.on;
    }

}

export default PracticeDetailsInfo;

enum PracticeDetailsToggleType {
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