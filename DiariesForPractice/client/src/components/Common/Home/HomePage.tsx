import React, { Component } from "react";
import { RootStore } from "../../../stores/RootStore";
import { Label } from "reactstrap";
import { StudentsQueryReadModel } from "../../../Typings/readModels/StudentsQueryReadModel";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import Students from "./Students/Students";
import Filters from "./Filters/Filters";

class IHomePageProps {
    store: RootStore;
}

@observer
class HomePage extends Component<IHomePageProps> {
    studentsQuery: StudentsQueryReadModel;

    constructor(props: IHomePageProps) {
        super(props);
        makeObservable(this, {
            studentsQuery: observable
        });
    }

    renderTitle() {
        return (
            <div className="row justify-content-center" style={{marginTop: "5%", fontSize: "2.5em"}}>
                <Label>
                    Генерация отчётов по практике
                </Label>
            </div>
        );
    }

    renderFilters() {
        return (
            <Filters store={this.props.store} updateFilters={this.updateFilters} />
        );
    }

    renderStudents() {
        return (
            <Students store={this.props.store} studentsQuery={this.studentsQuery} />
        );
    }

    render() {
        return(
            <div className="container-fluid">
                {this.renderTitle()}
                {this.renderFilters()}
                {this.renderStudents()}
            </div>
        );
    }

    updateFilters(query: StudentsQueryReadModel) {
        this.studentsQuery = query;
        this.props.store.studentStore.searchStudentsByQuery(query);
    }
}

export default HomePage;