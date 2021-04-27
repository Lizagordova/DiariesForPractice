import React, { Component } from "react";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import {GroupToHandle} from "./Models/GroupToHandle";

class IAddOrUpdateGroupProps {
    groupToHandle: GroupToHandle;
    updateGroup: any;
    isNew: boolean;
}

@observer
class AddOrUpdateGroup extends Component<IAddOrUpdateGroupProps> {
    constructor(props: IAddOrUpdateGroupProps) {
        super(props);
        makeObservable(this, {

        });
    }

    render() {
        return (
            <></>
        );
    }
}

export default AddOrUpdateGroup;