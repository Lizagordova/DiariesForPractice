import React, { Component } from "react";
import { observer } from "mobx-react";
import { RootStore } from "../../../stores/RootStore";

class HomePageProps {
    store: RootStore;
}

@observer
class HomePage extends Component<HomePageProps> {
    constructor(props: HomePageProps) {
        super(props);
    }
    
    render() {
        return (
            <></>
        );
    }
}

export default HomePage;