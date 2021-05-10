import React, { Component } from "react";
import { observer } from "mobx-react";
import { PracticeViewModel } from "../../../../Typings/viewModels/PracticeViewModel";
import { makeObservable, observable } from "mobx";
import { Dropdown, DropdownItem, DropdownMenu, DropdownToggle, Input } from "reactstrap";
import { ReportingForm } from "../../../../Typings/enums/ReportingForm";
import { translateReportingForm } from "../../../../functions/translater";

class PracticeDetailsInfoProps {
    practiceDetails: PracticeViewModel;
    update: any;
    edit: boolean;
}

@observer
class PracticeDetailsInfo extends Component<PracticeDetailsInfoProps> {
    practiceDetails: PracticeViewModel = new PracticeViewModel();
    reportingFormOpen: boolean;
    update: boolean;
    
    constructor(props: PracticeDetailsInfoProps) {
        super(props);
        makeObservable(this, {
            practiceDetails: observable,
            reportingFormOpen: observable,
            update: observable
        });
        this.setPracticeDetails();
    }

    setPracticeDetails() {
        this.practiceDetails = this.props.practiceDetails;
    }

    renderReportingForm() {
        let { edit } = this.props;
        return(
            <Dropdown isOpen={this.reportingFormOpen} toggle={() => this.reportingFormToggle()}>
                <DropdownToggle caret>
                    {}
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
        )
    }

    renderContactNumber(contractNumber: string) {
        let { edit } = this.props;
        return(
            <>
                {!edit && <span>{contractNumber}</span>}
                {!edit && <Input
                    placeholder="Номер договора"
                    value={this.practiceDetails.contractNumber}
                    onChange={(event) => this.changeContractNumber(event)}>
                    {this.practiceDetails.contractNumber}
                </Input>}
            </>
        );
    }
    
    renderPracticeDetailsInfo(update: boolean) {
        return(
            <>
                <div className="row justify-content-center">
                    {this.renderReportingForm()}  
                </div>
                <div className="row justify-content-center">
                    {this.renderContactNumber(this.practiceDetails.contractNumber)}
                </div>
            </>
        );
    }
    
    render() {
        return (
            <>
                {this.renderPracticeDetailsInfo(this.update)}
            </>
        );
    }

    reportingFormToggle() {
        this.reportingFormOpen = !this.reportingFormOpen;
    }

    chooseReportingForm(reportingForm: ReportingForm) {
        this.practiceDetails.reportingForm = reportingForm;
        this.updateToggle();
    }
    
    updateToggle() {
        this.update = !this.update;
    }

    changeContractNumber(event: React.ChangeEvent<HTMLInputElement>) {
        this.practiceDetails.contractNumber = event.currentTarget.value;
    }
}

export default PracticeDetailsInfo;