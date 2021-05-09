import React, { Component } from "react";
import { RootStore } from "../../stores/RootStore";
import { observer } from "mobx-react";

class AuthorizationTabProps {
    store: RootStore;
}

@observer
class AuthorizationTab extends Component<AuthorizationTabProps> {
    constructor(props: AuthorizationTabProps) {
        super(props);
    }

    render() {
        return(
            <>
            </>
        );
    }
}

export default AuthorizationTab;