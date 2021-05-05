import React, { Component } from "react";
import { RootStore } from "../../../stores/RootStore";
import { observer } from "mobx-react";

class GroupPageProps {
    store: RootStore
}

@observer
class GroupsPage extends Component<GroupPageProps> {
    constructor(props: GroupPageProps) {
        super(props);
    }

    render() {
        return (
            <></>
        );
    }
}

export default GroupsPage;