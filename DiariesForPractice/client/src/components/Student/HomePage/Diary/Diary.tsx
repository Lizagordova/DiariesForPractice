import React, { Component } from "react";
import { RootStore } from "../../../../stores/RootStore";
import { observer } from "mobx-react";
import { DiaryViewModel } from "../../../../Typings/viewModels/DiaryViewModel";
import DiaryCompletion from "./DiaryCompletion";
import DiaryPreview from "./DiaryPreview";
import { makeObservable, observable } from "mobx";
import { Button, Alert } from "reactstrap";
import {PracticeReadModel} from "../../../../Typings/readModels/PracticeReadModel";

class DiaryProps {
    store: RootStore;
    studentId: number;
}

@observer
class Diary extends Component<DiaryProps> {
    diary: DiaryViewModel = new DiaryViewModel();
    notRegenerated: boolean;
    
    constructor(props: DiaryProps) {
        super(props);
        makeObservable(this, {
            diary: observable,
            notRegenerated: observable
        });
        this.setDiary();
    }
    
    setDiary() {
        let { store } = this.props;
        let diary = store.diariesStore.diaries.find(d => d.studentId = this.props.studentId);
        if(diary !== undefined) {
            this.diary = diary;
        }
    }

    renderWarnings() {
        setTimeout(() => {
            this.notRegenerated = false;
        })
        return (
            <>
                {this.notRegenerated && <Alert>Что-то пошло не так, и не удалось перегенерировать дневник.</Alert>}
            </>
        );
    }
    
    renderRegenerateButton() {
        return (
            <div className="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-xs-12">
                <Button
                    outline color="secondary"
                    onClick={() => this.regenerate()}>
                    Перегенерировать
                </Button>
            </div>
        );
    }

    renderDownloadButton(diary: DiaryViewModel) {
        if(diary.completion > 90) {
            return (
                <div className="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <a href="#"
                        onClick={() => this.download()}>
                        Скачать
                    </a>
                </div>
            );
        }
    }
    
    renderControls() {
        return (
            <>
                {this.renderRegenerateButton()}
                {this.renderDownloadButton(this.diary)}
            </>
        );
    }
    
    renderDiary(diary: DiaryViewModel) {
        return (
            <>
                <div className="row justify-content-center">
                    <DiaryCompletion diary={diary} />
                </div>
                <div className="row justify-content-center">
                    <DiaryPreview diary={diary} store={this.props.store} />
                </div>
                <div className="row justify-content-center">
                    {this.renderControls()}
                </div>
            </>
        );
    }
    
    render() {
        return(
            <>
                {this.renderWarnings()}
                {this.renderDiary(this.diary)}
            </>
        );
    }

    regenerate() {
        this.props.store.diariesStore
            .generateDiary(this.props.studentId)
            .then((status) => {
                if(status === 200) {
                    this.setDiary();
                } else {
                    this.notRegenerated = true;
                }
            });
    }

    download() {
        this.props.store.diariesStore
            .addOrUpdateDiary();
    }
}

export default Diary;