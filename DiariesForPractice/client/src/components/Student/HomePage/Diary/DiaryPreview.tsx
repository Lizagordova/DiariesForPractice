import React, { Component } from "react";
import { observer } from "mobx-react";
import { DiaryViewModel } from "../../../../Typings/viewModels/DiaryViewModel";
import { makeObservable, observable } from "mobx";
import DiariesStore from "../../../../stores/DiariesStore";

class DiaryPreviewProps {
    diariesStore: DiariesStore;
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
        this.diary = this.props.diary;
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
            <>
                <div className="row justify-content-center">
                    {this.renderDiaryPreview(this.diary)}
                </div>
            </>
        );
    }

    regenerate() {
        return (
            <></>
        );
    }
}

export default DiaryPreview;

enum ControlType {
    Regenerate,
    Download
}