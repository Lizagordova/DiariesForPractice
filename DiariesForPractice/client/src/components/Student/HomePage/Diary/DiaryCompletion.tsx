import React, { Component } from "react";
import { observer } from "mobx-react";
import { DiaryViewModel } from "../../../../Typings/viewModels/DiaryViewModel";

class DiaryCompletionProps {
    diary: DiaryViewModel;
}

@observer
class DiaryCompletion extends Component<DiaryCompletionProps> {
    constructor(props: DiaryCompletionProps) {
        super(props);
    }

    render() {
        return (
            <></>
        );
    }
}

export default DiaryCompletion;