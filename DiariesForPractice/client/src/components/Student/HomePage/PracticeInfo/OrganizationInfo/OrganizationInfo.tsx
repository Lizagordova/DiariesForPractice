import React, {Component} from "react";
import {observer} from "mobx-react";
import {makeObservable, observable} from "mobx";
import {Alert, Input, Label, Progress} from "reactstrap";
import {OrganizationViewModel} from "../../../../../Typings/viewModels/OrganizationViewModel";
import {RootStore} from "../../../../../stores/RootStore";
import {mapToOrganizationReadModel} from "../../../../../functions/mapper";
import {OrganizationDataType} from "../../../../../consts/OrganizationDataType";
import {translateOrganizationType} from "../../../../../functions/translater";
import {ToggleType} from "../../../../../consts/ToggleType";
import {warningTypeRenderer} from "../../../../../functions/warningTypeRenderer";
import {WarningType} from "../../../../../consts/WarningType";

class OrganizationProps {
    organization: OrganizationViewModel;
    store: RootStore;
    practiceDetailsId: number;
    updateOrganization: any;
}

@observer
class OrganizationInfo extends Component<OrganizationProps> {
    organization: OrganizationViewModel = new OrganizationViewModel();
    edit: boolean;
    notSaved: boolean;
    saved: boolean;
    progress: HTMLDivElement | null;

    constructor(props: OrganizationProps) {
        super(props);
        makeObservable(this, {
            organization: observable,
            edit: observable,
            notSaved: observable,
            saved: observable,
            progress: observable,
        });
        this.setOrganization();
    }

    componentDidMount() {
        this.updateProgress();
    }

    setOrganization() {
        this.organization = this.props.organization;
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

    renderOrganizationData(data: string, organizationType: OrganizationDataType) {
        if(data === null || data === undefined) {
            data = "";
        }
        return (
            <>
                <div className="col-lg-3 col-md-3 col-sm-12">
                    <Label className="studentInfoDataLabel">{translateOrganizationType(organizationType)}</Label>
                </div>
                <div className="col-lg-9 col-md-9 col-sm-12">
                    <Input
                        onInput={() => this.editToggle(ToggleType.on)}
                        className="studentInfoInput"
                        value={data}
                        defaultValue={data}
                        onChange={(event) => this.inputData(event, organizationType)}
                    />
                </div>
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
        let progressPercentage = this.computeProgress(this.organization);
        let progress = this.progress;
        if(progress !== null && progress !== undefined) {
            progress.style.width = progressPercentage.toString() + "%";
        }
        this.progress = progress;
    }
    
    renderHeader(edit: boolean) {
        return (
            <>
                <Label className="studentInfoTitleLabel">Организация</Label>
                {edit && <i className="fa fa-save fa-2x icon" onClick={() => this.save()}/>}
                {edit && <i className="fa fa-window-close fa-2x icon" onClick={() => this.editToggle(ToggleType.off)} />}
            </>
        );
    }

    renderOrganizationInfo(organization: OrganizationViewModel, edit: boolean) {
        return (
            <>
                {this.renderWarnings()}
                <div className="row justify-content-center">
                    {this.renderHeader(edit)}
                </div>
                <div className="row justify-content-center">
                    {this.renderProgress()}
                </div>
                <div className="row studentInfoBlock">
                    {this.renderOrganizationData(organization.name, OrganizationDataType.OrganizationName)}
                </div>
                <div className="row studentInfoBlock">
                    {this.renderOrganizationData(organization.legalAddress, OrganizationDataType.OrganizationLegalAddress)}
                </div>
            </>
        );
    }

    render() {
        return(
            <>
                {this.renderOrganizationInfo(this.organization, this.edit)}
            </>
        );
    }

    inputData(event: React.ChangeEvent<HTMLInputElement>,organizationType: OrganizationDataType) {
        let value = event.currentTarget.value;
        if(organizationType === OrganizationDataType.OrganizationName) {
            this.organization.name = value;
        } else if(organizationType === OrganizationDataType.OrganizationLegalAddress) {
            this.organization.legalAddress = value;
        }
        this.updateProgress();
    }

    computeProgress(organization: OrganizationViewModel): number {
        let progress = 0;
        if(organization.name !== "") {
            progress += 50;
        }
        if(organization.legalAddress !== "") {
            progress += 50;
        }

        return progress;
    }

    editToggle(type: ToggleType) {
        this.edit = type === ToggleType.on;
    }

    save() {
        let organization = mapToOrganizationReadModel(this.organization, this.props.practiceDetailsId);
        this.props.store.organizationStore.addOrUpdateOrganization(organization)
            .then((organizationId) => {
                if(organizationId === 0) {
                    this.notSaved = true;
                } else {
                    this.saved = true;
                    this.editToggle(ToggleType.off);
                    let organization = new OrganizationViewModel();
                    organization.id = organizationId;
                    this.organization = organization;
                    this.props.updateOrganization(organization);
                }
            });
    }
}

export default OrganizationInfo;