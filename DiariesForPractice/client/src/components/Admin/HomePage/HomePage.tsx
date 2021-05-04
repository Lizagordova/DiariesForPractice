import React, { Component } from "react";
import { RootStore } from "../../../stores/RootStore";

class HomePageProps {
    store: RootStore
}

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