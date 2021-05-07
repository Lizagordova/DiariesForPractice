import React, { Component } from "react";
import { RootStore } from "../../../stores/RootStore";
import { observer } from "mobx-react";

class HomePageProps {
    store: RootStore
}

@observer
class HomePage extends Component<HomePageProps> {
    constructor(props: HomePageProps) {
        super(props);
    }

    renderStudentInfo() {
        return(
            <></>
        );
    }
    
    renderDiary() {
        return (
            <></>
        );
    }
    
    render() {
        return (
            <>
                <div className="row justify-content-center">
                    <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                        {this.renderUserInfo()}
                    </div>
                    <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                        {this.renderDiary()}
                    </div>
                </div>
            </>
        );
    }
}

export default HomePage;