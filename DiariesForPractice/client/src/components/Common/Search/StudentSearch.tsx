import React, { Component } from "react";
import { observer } from "mobx-react";
import InstituteDetailsStore from "../../../stores/InstituteDetailsStore";

class StudentSearchProps {
    instituteStore: InstituteDetailsStore;
}

@observer
class StudentSearch extends Component<StudentSearchProps> {
    renderSearchBar() {
        return (
            <></>
        );
    }
    
    render() {
        return (
            <></>
        )
    };
}

export default StudentSearch;