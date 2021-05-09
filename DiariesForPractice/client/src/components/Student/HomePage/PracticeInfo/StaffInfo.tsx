import React, { Component } from "react";
import {StaffViewModel} from "../../../../Typings/viewModels/StaffViewModel";
import { StaffRole } from "../../../../Typings/enums/StaffRole";
import { observer } from "mobx-react";

class StaffInfoProps {
    staff: StaffViewModel;
    role: StaffRole;
    edit: boolean;
    updateStaffInfo: any;
}

@observer
class StaffInfo extends Component<StaffInfoProps> {
    constructor(props: StaffInfoProps) {
        super(props);
    }
    
    render() {
        return (
            <></>
        );
    }
}

export default StaffInfo;