import React, { Component } from "react";
import { observer } from "mobx-react";
import { DiaryViewModel } from "../../../../Typings/viewModels/DiaryViewModel";
import { makeObservable, observable } from "mobx";
import DiariesStore from "../../../../stores/DiariesStore";
import DiaryPreview from "./DiaryPreview";
import { Button } from "reactstrap";

class DiaryWindowProps {
    diaryStore: DiariesStore;
    studentId: number;
}

@observer
class DiaryWindow extends Component<DiaryWindowProps> {
    diary: DiaryViewModel = new DiaryViewModel();
    
    constructor(props: DiaryWindowProps) {
        super(props);
        makeObservable(this, {
            diary: observable
        });
    }
    
    setDiary() {
        let studentId = this.props.studentId;
        this.props.diaryStore.getDiary(studentId)
            .then((diary) => {
                this.diary = diary;
            });
    }
    
    renderDiaryCompletionInfo() {
        return (
            <></>
        );
    }
    
    renderDiaryPreview(diary: DiaryViewModel) {
        return (
            <DiaryPreview diary={diary} diariesStore={this.props.diaryStore} />
        );
    }

    renderDownloadButton(diaryPath: string) {
        return (
            <a href={diaryPath}>
                Скачать
            </a>
        );
    }
    
    renderRegenerateButton() {
        return (
            <Button
                color="primary"
                onClick={() => this.regenerateDiary()}>
            </Button>
        );
    }
    
    renderControls() {
        return (
            <>
                <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    {this.renderDownloadButton(this.diary.path)}
                </div>
                <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    {this.renderRegenerateButton()}
                </div>
            </>
        );
    }
    
    renderDiary(diary: DiaryViewModel) {
        return(
            <>
                <div className="row justify-content-center">
                    {this.renderDiaryPreview(diary)}
                </div>
                <div className="row justify-content-center">
                    {this.renderControls()}
                </div>
            </>
        );
    }
    
    render() {
        return (
            <>
                <div className="row justify-content-center">
                    {this.renderDiaryCompletionInfo()}
                </div>
                {this.renderDiary(this.diary)}
            </>
        );
    }

    regenerateDiary() {
        this.props.diaryStore.generateDiary(this.props.studentId)
            .then(() => {
                
            })//todo: надо добавить ещё наверно 
        // предупреждение что если чел не сохранил изменения, то и от перегенерации ждать нечего
    }
}

export default DiaryWindow;