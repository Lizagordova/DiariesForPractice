import React, { Component } from "react";
import { observer } from "mobx-react";
import { DiaryViewModel } from "../../../../Typings/viewModels/DiaryViewModel";
import { Progress } from "reactstrap";

class DiaryCompletionProps {
    diary: DiaryViewModel;
}

@observer
class DiaryCompletion extends Component<DiaryCompletionProps> {
    constructor(props: DiaryCompletionProps) {
        super(props);
    }

    renderCompletion(completion: number) {
        return (
            <div className="row justify-content-center">
                <Progress value={completion}>
                    Дневник заполнен на {completion}
                </Progress>
            </div>
        );
    }
    
    renderComment(comment: string) {
        return (
            <div className="row justify-content-center">
                <span>{comment}</span>
            </div>
        );
    }
    
    render() {
        return (
            <div className="container-fluid">
                {this.renderCompletion(this.props.diary.completion)}
                {this.renderComment(this.props.diary.comment)}
            </div>
        );
    }
}

export default DiaryCompletion;