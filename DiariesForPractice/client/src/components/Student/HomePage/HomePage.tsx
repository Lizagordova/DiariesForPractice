import React, { Component } from "react";
import { RootStore } from "../../../stores/RootStore";
import { observer } from "mobx-react";
import { DiaryViewModel } from "../../../Typings/viewModels/DiaryViewModel";
import { Alert } from "reactstrap";
import { makeObservable, observable } from "mobx";
import StudentPracticeInfo from "./PracticeInfo/StudentPracticeInfo";

class HomePageProps {
    store: RootStore
}

@observer
class HomePage extends Component<HomePageProps> {
    studentDiary: DiaryViewModel = new DiaryViewModel();
    
    constructor(props: HomePageProps) {
        super(props);
        makeObservable(this, {
            studentDiary: observable
        });
        this.setStudentDiary();
    }

    setStudentDiary() {
        let { store } = this.props;
        let currentUser = store.userStore.currentUser;
        let diary = store.diariesStore.diaries.find(d => d.studentId = currentUser.id);
        if(diary !== undefined) {
            this.studentDiary = diary;
        }
    }

    renderDiary(diary: DiaryViewModel) {
        if(diary.generated) {
            return (
                <embed src={diary.path}>
                    some name
                </embed>
            );
        } else {
            return (
                <Alert color="secondary">
                    {diary.comment}
                </Alert>
            );
        }
    }
    
    render() {
        return (
            <>
                <div className="row justify-content-center">
                    <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                        <StudentPracticeInfo store={this.props.store} />
                    </div>
                    <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                        {this.renderDiary(this.studentDiary)}
                    </div>
                </div>
            </>
        );
    }
}

export default HomePage;