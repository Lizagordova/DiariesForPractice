import React, { Component } from "react";
import { RootStore } from "../../stores/RootStore";
import { observer } from "mobx-react";
import { makeObservable } from "mobx";

class RegistrationWindowProps {
    store: RootStore;
}

@observer
class RegistrationWindow extends Component<RegistrationWindowProps> {
    constructor(props: RegistrationWindowProps) {
        super(props);
        makeObservable(this, {
            
        })
    }
    
    renderRegistrationWindow() {
        return (
            <></>
        );
    }
    
    render() {
        return (
            <div className="container-fluid">
                
            </div>
        );
    }
}

export default RegistrationWindow;