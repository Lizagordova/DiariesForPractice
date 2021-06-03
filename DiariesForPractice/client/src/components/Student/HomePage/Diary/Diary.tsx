import React, { Component } from "react";
import { observer } from "mobx-react";
import { DiaryViewModel } from "../../../../Typings/viewModels/DiaryViewModel";
import DiaryCompletion from "./DiaryCompletion";
import DiaryPreview from "./DiaryPreview";
import { makeObservable, observable } from "mobx";
import { Button, Alert } from "reactstrap";
import { mapToDiaryReadModel } from "../../../../functions/mapper";
import DiariesStore from "../../../../stores/DiariesStore";

class DiaryProps {
    diariesStore: DiariesStore;
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
        let { diariesStore } = this.props;
        let diary = diariesStore.diaries.find(d => d.studentId = this.props.studentId);
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
                    <DiaryPreview diary={diary} diariesStore={this.props.diariesStore} />
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
        this.props.diariesStore
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
        let diary = mapToDiaryReadModel(this.diary);
        diary.perceivedDate = Date.now();//todo: может, по-другому
        this.props.diariesStore
            .addOrUpdateDiary(diary);
    }
}

export default Diary;