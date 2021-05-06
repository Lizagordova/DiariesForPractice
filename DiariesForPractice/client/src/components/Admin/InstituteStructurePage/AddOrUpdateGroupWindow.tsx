import React, { Component } from "react";
import InstituteEntityProps from "../../../models/InstituteEnitityProps";
import { observer } from "mobx-react";
import { GroupViewModel } from "../../../Typings/viewModels/GroupViewModel";
import { makeObservable, observable } from "mobx";
import { CafedraViewModel } from "../../../Typings/viewModels/CafedraViewModel";
import { Dropdown, DropdownItem, DropdownMenu, DropdownToggle, Input, Table } from 'reactstrap';
import { InstituteEntityType } from "../../../consts/InstituteEntity";
import { InstituteViewModel } from "../../../Typings/viewModels/InstituteViewModel";
import { DirectionViewModel } from "../../../Typings/viewModels/DirectionViewModel";
import { UserViewModel } from "../../../Typings/viewModels/UserViewModel";


@observer
class AddOrUpdateGroupWindow extends Component<InstituteEntityProps> {
    group: GroupViewModel;
    update: boolean;
    instituteOpen: boolean;
    cafedraOpen: boolean;
    directionOpen: boolean;
    currentInstitute: InstituteViewModel = new InstituteViewModel();
    currentDirection: DirectionViewModel = new DirectionViewModel();
    currentCafedra: CafedraViewModel = new CafedraViewModel();
    teachers: UserViewModel[] = new Array<UserViewModel>();

    constructor(props: InstituteEntityProps) {
        super(props);
        makeObservable(this, {
            group: observable,
            update: observable,
            instituteOpen: observable,
            cafedraOpen: observable,
            directionOpen: observable,
            currentInstitute: observable,
            currentDirection: observable,
            currentCafedra: observable,
            teachers: observable
        });
    }

    renderNameInput() {
        return (
            <div className="row justify-content-center">
                <Input
                    name={this.group.name}
                    onChange={(e) => this.changeNameGroup(e)}
                />
            </div>
        );
    }

    renderInstitute(institute: InstituteViewModel, update: boolean) {
        let { institutes } = this.props.instituteStore;
        return (
            <div className="row justify-content-center">
                <Dropdown isOpen={this.instituteOpen}
                          toggle={() => this.instituteEntityToggle(InstituteEntityType.Institute)}>
                    <DropdownToggle caret>
                        {institute.name}
                    </DropdownToggle>
                    <DropdownMenu>
                        {institutes.map((institute) => {
                            return (
                                <DropdownItem
                                    key={institute.id}
                                    onClick={() => this.chooseInstitute(institute)}>
                                    {institute.name}
                                </DropdownItem>
                            );
                        })}
                    </DropdownMenu>
                </Dropdown>
            </div>
        );
    }

    renderDirection(direction: DirectionViewModel, update: boolean) {
        let {directions} = this.props.instituteStore;
        return (
            <div className="row justify-content-center">
                <Dropdown isOpen={this.directionOpen}
                          toggle={() => this.instituteEntityToggle(InstituteEntityType.Direction)}>
                    <DropdownToggle caret>
                        {direction.name}
                    </DropdownToggle>
                    <DropdownMenu>
                        {directions.map((direction) => {
                            return (
                                <DropdownItem
                                    key={direction.id}
                                    onClick={() => this.chooseDirection(direction)}>
                                    {direction.name}
                                </DropdownItem>
                            );
                        })}
                    </DropdownMenu>
                </Dropdown>
            </div>
        );
    }

    renderCafedra(cafedra: CafedraViewModel, update: boolean) {
        let { cafedras } = this.props.instituteStore;//todo: здесь лучше выпадающий список
        return (
            <div className="row justify-content-center">
                <Dropdown isOpen={this.cafedraOpen} toggle={() => this.instituteEntityToggle(InstituteEntityType.Cafedra)}>
                    <DropdownToggle caret>
                        {cafedra.name}
                    </DropdownToggle>
                    <DropdownMenu>
                        {cafedras.map((cafedra) => {
                            return (
                                <DropdownItem
                                    key={cafedra.id}
                                    onClick={() => this.chooseCafedra(cafedra)}>
                                    {cafedra.name}
                                </DropdownItem>
                            );
                        })}
                    </DropdownMenu>
                </Dropdown>
            </div>
        );
    }

    renderResponsible(responsible: UserViewModel, teachers: UserViewModel[], update: boolean) {
        return (
            <div className="row justify-content-center">
                <Dropdown isOpen={this.cafedraOpen} toggle={() => this.instituteEntityToggle(InstituteEntityType.Cafedra)}>
                    <DropdownToggle caret>
                        {`${responsible.firstName} ${responsible.secondName} ${responsible.lastName}`}
                    </DropdownToggle>
                    <DropdownMenu>
                        {teachers.map((teacher) => {
                            return (
                                <DropdownItem
                                    key={teacher.id}
                                    onClick={() => this.chooseResponsible(teacher)}>
                                    {teacher.name}
                                </DropdownItem>
                            );
                        })}
                    </DropdownMenu>
                </Dropdown>
            </div>
        );
    }

    renderStudents(students: UserViewModel[], update: boolean) {
        return (
            <div className="row justify-content-center">
                <Table>
                    <thead>
                    <tr>
                        <th>ФИО</th>
                        <th>Контрол</th>
                    </tr>
                    </thead>
                    <tbody>
                    {students.map((student) => {
                        return (
                            <tr>
                                <th>
                                    {`${student.firstName} ${student.secondName} ${student.lastName}`}
                                </th>
                                <th>
                                    <i className="fas fa-trash-alt" onClick={() => this.deleteStudentFromGroup(student)}/>
                                </th>
                            </tr>
                        );
                    })}
                    </tbody>
                </Table>
                <i className="fas fa-plus-circle fa-3x" onClick={() => this.addStudentToGroup()}/>
            </div>
        );
    }

    render() {
        return (
            <>
                {this.renderNameInput()}
                {this.renderInstitute(this.currentInstitute, this.update)}
                {this.renderDirection(this.currentDirection, this.update)}
                {this.renderCafedra(this.currentCafedra, this.update)}
                {this.renderResponsible(this.responsible, this.teachers, this.update)}
                {this.renderStudents(this.group.students, this.update)}
            </>
        );
    }

    updateToggle() {
        this.update = !this.update;
    }

    instituteEntityToggle(instituteEntity: InstituteEntityType) {
        if (instituteEntity === InstituteEntityType.Institute) {
            this.instituteOpen = !this.instituteOpen;
        } else if (instituteEntity === InstituteEntityType.Direction) {
            this.directionOpen = !this.directionOpen;
        } else if (instituteEntity === InstituteEntityType.Cafedra) {
            this.cafedraOpen = !this.cafedraOpen;
        }
    }

    chooseInstitute(institute: InstituteViewModel) {
        this.currentInstitute = institute;
        this.updateToggle();
    }

    chooseDirection(direction: DirectionViewModel) {
        this.currentDirection = direction;
        this.updateToggle();
    }

    chooseCafedra(cafedra: CafedraViewModel) {
        this.currentCafedra = cafedra;
        this.updateToggle();
    }

    changeNameGroup(event: React.ChangeEvent<HTMLInputElement>) {
        this.group.name = event.currentTarget.value;//todo: чем отличается currentTarget от простого target?
    }

    deleteStudentFromGroup(student: UserViewModel) {
        this.group.students = this.group.students.filter(s => s.id !== student.id);
        this.updateToggle();
    }

    chooseResponsible(teacher: UserViewModel) {
        this.group.responsible = teacher;
        this.updateToggle();
    }
}


export default AddOrUpdateGroupWindow;