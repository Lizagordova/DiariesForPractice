import React, { Component } from "react";
import { observer } from "mobx-react";
import { DiaryViewModel } from "../../../../Typings/viewModels/DiaryViewModel";
import { makeObservable, observable } from "mobx";

class DiaryPreviewProps {
    diary: DiaryViewModel;
}

@observer
class DiaryPreview extends Component<DiaryPreviewProps> {
    diary: DiaryViewModel = new DiaryViewModel();
    
    constructor(props: DiaryPreviewProps) {
        super(props);
        makeObservable(this, {
            diary: observable
        });
    }
    
    renderDiaryPreview(diary: DiaryViewModel) {
        return (
            <embed src={diary.path}>
                {diary.path}
            </embed>
        );
    }
    
    render() {
        return (
            <></>
        );
    }
}

export default DiaryPreview;