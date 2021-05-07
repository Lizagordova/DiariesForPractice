import React, { Component } from "react";
import { observer } from "mobx-react";
import { RootStore } from "../../../stores/RootStore";

class GroupsPageProps {
    store: RootStore;
}

@observer
class GroupsPage extends Component<GroupsPageProps> {
    constructor(props: GroupsPageProps) {
        super(props);
    }

    render() {
        return (
            <></>
        );
    }
}

export default GroupsPage;