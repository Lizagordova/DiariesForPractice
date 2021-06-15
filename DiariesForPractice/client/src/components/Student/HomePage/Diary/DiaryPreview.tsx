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
    
    renderWord(diary: DiaryViewModel) {
        return (
            <div id="content">
                <div style={{height: "800px"}}>
                    <iframe id="optomaFeed" 
                            src="Content/test.htm" scrolling="yes"
                            frameBorder="0" height="100%" width="100%"
                            style={{position: "absolute", clip: "rect(190px,1100px,800px,250px)"}}
                    />
                </div>
            </div>
        );
    }
    
    render() {
        return (
            <>
                <div className="row justify-content-center">
                    {this.renderWord(this.diary)}
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