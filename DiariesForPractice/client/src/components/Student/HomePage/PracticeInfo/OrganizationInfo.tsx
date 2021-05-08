import React, { Component } from "react";
import { observer } from "mobx-react";

class OrganizationInfoProps {

}

@observer
class OrganizationInfo extends Component<OrganizationInfoProps> {
    organization: OrganizationViewModel = new OrganizationViewModel();
    constructor(props: OrganizationInfoProps) {
        super(props);
    }

    render() {
        return(
            <>
            </>
        );
    }
}

export default OrganizationInfo;