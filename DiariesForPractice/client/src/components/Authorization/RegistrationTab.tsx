import React, { Component } from "react";
import { RootStore } from "../../stores/RootStore";
import { observer } from "mobx-react";

class RegistrationTabProps {
    store: RootStore;
}

@observer
class RegistrationTab extends Component<RegistrationTabProps> {
    constructor(props: RegistrationTabProps) {
        super(props);
    }
    
    render() {
        return (
            <>
            </>
        );
    }
}
export default RegistrationTab;