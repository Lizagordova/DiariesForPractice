import React, { Component}  from "react";
import { observer } from "mobx-react";

class IOrganizationInfoProps {
    
}

@observer
class OrganizationInfo extends Component<IOrganizationInfoProps> {
    constructor(props: IOrganizationInfoProps) {
        super(props);
    }
    
    render() {
        return(
            <></>
        );
    }
}

export default OrganizationInfo;