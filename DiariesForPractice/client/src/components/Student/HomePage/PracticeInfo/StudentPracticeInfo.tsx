import React, { Component } from "react";
import { observer } from "mobx-react";
import { RootStore } from "../../../../stores/RootStore";
import PersonalInfo from "./PersonalInfo";
import PracticeInfo from "./PracticeInfo";

class PracticeInfoProps {
    store: RootStore;
}

@observer
class StudentPracticeInfo extends Component<PracticeInfoProps> { 
    renderInfo() {
        let { store } = this.props;
        return(
            <>
                <div className="row justify-content-center">
                    <PersonalInfo store={store} />
                </div>
                <div className="row justify-content-center">
                    <PracticeInfo store={store} />
                </div>
            </>
        );
    }
    
    render() {
        return (
            <>
                {this.renderInfo()}
            </>
        );
    }
}

export default StudentPracticeInfo;