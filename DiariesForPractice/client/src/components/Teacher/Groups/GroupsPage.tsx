﻿import React, { Component } from "react";
import { observer } from "mobx-react";
import { RootStore } from "../../../stores/RootStore";
import { GroupViewModel } from "../../../Typings/viewModels/GroupViewModel";
import { makeObservable, observable } from "mobx";
import Group from "./Group";

class GroupsPageProps {
    store: RootStore;
}

class GroupToTransfer {
    group: GroupViewModel;
    transferDirection: TransferDirection;
}

enum TransferDirection {
    ToMyGroups,
    FromMyGroups
}

@observer
class GroupsPage extends Component<GroupsPageProps> {
    myGroups: GroupViewModel[] = new Array<GroupViewModel>();
    restGroups: GroupViewModel[] = new Array<GroupViewModel>();
    update: boolean;
    groupToTransfer: GroupToTransfer = new GroupToTransfer();
    groupToShow: GroupViewModel = new GroupViewModel();
    groupHasResponsibleAlready: boolean;
    showGroup: boolean;
    
    constructor(props: GroupsPageProps) {
        super(props);
        makeObservable(this, {
            myGroups: observable,
            restGroups: observable,
            update: observable,
            groupToTransfer: observable,
            groupToShow: observable,
            groupHasResponsibleAlready: observable
        });
    }

    renderMyGroups(groups: GroupViewModel[]) {
        return (
            <>
                {groups.map((group) => {
                    return (
                        <div className="row justify-content-center">
                            <span
                                onClick={() => {this.chooseGroupToTransfer(group, TransferDirection.FromMyGroups)}}
                                onDoubleClick={() => this.groupDetailsToggle(group)}>
                                {group.name}
                            </span>
                        </div>
                    );
                })}
            </>
        );
    }
    
    renderRestGroups(groups: GroupViewModel[]) {
        return (
            <>
                {groups.map((group) => {
                    return (
                        <div className="row justify-content-center">
                        <span
                            onClick={() => {this.chooseGroupToTransfer(group, TransferDirection.ToMyGroups)}}
                            >
                            {group.name}
                        </span>
                        </div>
                    );
                })}
            </>
        );
    }
    
    renderGroup(group: GroupViewModel) {
        return (
            <Group
                group={group} 
                toggle={this.groupShowToggle}  
                store={this.props.store} />
        );
    }
    
    render() {
        return (
            <>
                {this.showGroup && this.renderGroup(this.groupToShow)}
                <div className="row justify-content-center">
                    <div className="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                        {this.renderMyGroups(this.myGroups)}
                    </div>
                    <div className="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                        <i className="fas fa-exchange-alt" onClick={() => this.tryToTransferGroup()} />
                    </div>
                    <div className="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                        {this.renderRestGroups(this.restGroups)}
                    </div>
                </div>
                <div className="row justify-content-center">
                    
                </div>
            </>
        );
    }

    tryToTransferGroup() {
        if(this.groupToTransfer.group.responsible.id === 0) {
            this.groupHasResponsibleAlreadyToggle()
        }
    }
    
    chooseGroupToTransfer(group: GroupViewModel, transferDirection: TransferDirection) {
        let groupToTransfer = new GroupToTransfer();
        groupToTransfer.group = group;
        groupToTransfer.transferDirection = transferDirection;
        this.groupToTransfer = groupToTransfer;
    }

    groupDetailsToggle(group: GroupViewModel) {
        this.groupToShow = group;
        this.groupShowToggle();
    }

    groupHasResponsibleAlreadyToggle() {
        this.groupHasResponsibleAlready = !this.groupHasResponsibleAlready;
    }
    
    groupShowToggle() {
        this.showGroup = !this.showGroup;
    }
}

export default GroupsPage;