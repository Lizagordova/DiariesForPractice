import React, { Component } from "react";
import { observer } from "mobx-react";
import { RootStore } from "../../../stores/RootStore";
import { GroupViewModel } from "../../../Typings/viewModels/GroupViewModel";
import { makeObservable, observable } from "mobx";

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
    
    constructor(props: GroupsPageProps) {
        super(props);
        makeObservable(this, {
            myGroups: observable,
            restGroups: observable,
            update: observable,
            groupToTransfer: observable
        });
    }

    renderMyGroups(groups: GroupViewModel[]) {
        return (
            <></>
        );
    }
    
    renderRestGroups(groups: GroupViewModel[]) {
        return (
            <></>
        );
    }
    
    render() {
        return (
            <>
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
        
    }
    
    chooseGroupToTransfer(group: GroupViewModel, transferDirection: TransferDirection) {
        let groupToTransfer = new GroupToTransfer();
        groupToTransfer.group = group;
        groupToTransfer.transferDirection = transferDirection;
        this.groupToTransfer = groupToTransfer;
    }
}

export default GroupsPage;