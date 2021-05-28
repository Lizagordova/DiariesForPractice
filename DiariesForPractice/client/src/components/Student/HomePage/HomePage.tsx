import React, { Component } from "react";
import { RootStore } from "../../../stores/RootStore";
import { observer } from "mobx-react";
import { DiaryViewModel } from "../../../Typings/viewModels/DiaryViewModel";
import { makeObservable, observable } from "mobx";
import StudentPracticeInfo from "./PracticeInfo/StudentPracticeInfo";
import Diary from "./Diary/Diary";

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
    }

    render() {
        return (
            <>
                <div className="row justify-content-center">
                    <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                        <StudentPracticeInfo store={this.props.store} />
                    </div>
                    <div className="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                        <Diary store={this.props.store} />
                    </div>
                </div>
            </>
        );
    }
}

export default HomePage;