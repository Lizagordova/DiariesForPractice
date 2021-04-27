import React, { Component } from "react";
import { RootStore } from "../../../../stores/RootStore";
import { StudentViewModel } from "../../../../Typings/viewModels/StudentViewModel";
import { Accordion, Button } from "react-bootstrap";
import { Card, CardHeader, CardBody } from "reactstrap";
import { StudentsQueryReadModel } from "../../../../Typings/readModels/StudentsQueryReadModel";
import Student from "./Student";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";

class IStudentProps {
    store: RootStore;
    studentsQuery: StudentsQueryReadModel;
}

@observer
class Students extends Component<IStudentProps> {
    update: boolean;

    constructor(props: IStudentProps) {
        super(props);
        makeObservable(this, {
            update: observable
        });
    }

    renderStudents(students: StudentViewModel[]) {
        return (
            <Accordion defaultActiveKey="0">
                {students.map((student) => {
                    return (
                        <>
                            <CardHeader style={{backgroundColor: 'white'}}>
                                <Accordion.Toggle as={Button} variant="link" eventKey={student.id.toString()}>
                                    <span>{student.firstName + ' ' + student.lastName}</span>
                                </Accordion.Toggle>
                            </CardHeader>
                            <Accordion.Collapse eventKey={student.id.toString()} key={student.id.toString()}>
                                <CardBody>
                                    {<Student store={this.props.store} studentId={student.id}/>}
                                </CardBody>
                            </Accordion.Collapse>
                        </>
                    );
                })}
            </Accordion>
        );
    }

    render() {
        return(
            <div className="row justify-content-center">
                {this.renderStudents(this.props.store.studentStore.studentsByQuery)}
            </div>
        );
    }
}

export default Students;