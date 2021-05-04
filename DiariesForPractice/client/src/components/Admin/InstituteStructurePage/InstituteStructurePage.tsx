import React, { Component } from "react";
import InstituteDetailsStore from "../../../stores/InstituteDetailsStore";

class InstituteStructurePageProps {
    instituteStore: InstituteDetailsStore;
}

class InstituteStructurePage extends Component<InstituteStructurePageProps> {
    constructor(props: InstituteStructurePageProps) {
        super(props);
    }

    render() {
        return (
            <></>
        );
    }
}

export default InstituteStructurePage;