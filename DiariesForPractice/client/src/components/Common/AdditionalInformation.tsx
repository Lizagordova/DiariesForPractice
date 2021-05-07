import React, { Component } from "react";
import { observer } from "mobx-react";
import { RootStore } from "../../stores/RootStore";

class IAdditionalInformationProps {
    store: RootStore;
}

@observer
class AdditionalInformation extends Component<IAdditionalInformationProps> {
    constructor(props: IAdditionalInformationProps) {
        super(props);
    }
    
    render() {
        return (
            <>
            </>
        );
    }
}

export default AdditionalInformation;