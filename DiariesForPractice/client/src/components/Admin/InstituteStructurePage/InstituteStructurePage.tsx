import React, { Component } from "react";
import InstituteDetailsStore from "../../../stores/InstituteDetailsStore";
import Tree from 'react-tree-graph';
import 'react-tree-graph/dist/style.css'

class InstituteStructurePageProps {
    instituteStore: InstituteDetailsStore;
}

let data = {
    name: 'MISIS',
    children: [{
        name: 'ITASU'
    }, {
        name: 'EKOTEH'
    }, {
        name: 'INMIN'
    }]
}

//todo: прочитать статью на эту тему https://levelup.gitconnected.com/react-tree-graph-dcf96f8d5103
class InstituteStructurePage extends Component<InstituteStructurePageProps> {
    constructor(props: InstituteStructurePageProps) {
        super(props);
    }

    renderInstituteTree() {
        return (
            <Tree
                data={data}
                height={400}
                width={400}
            />
        );
    }
    
    render() {
        return (
            <>
                {this.renderInstituteTree()}
            </>
        );
    }
}

export default InstituteStructurePage;