﻿import React, { Component } from "react";
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

    render() {
        return (
            <></>
        );
    }
}

export default HomePage;