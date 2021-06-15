import React, {Component} from "react";
import {RootStore} from "../../../../stores/RootStore";
import {ButtonDropdown, DropdownItem, DropdownMenu, DropdownToggle} from "reactstrap";
import {makeObservable, observable} from "mobx";
import {DegreeViewModel} from "../../../../Typings/viewModels/DegreeViewModel";
import {CourseViewModel} from "../../../../Typings/viewModels/CourseViewModel";
import {GroupViewModel} from "../../../../Typings/viewModels/GroupViewModel";
import {InstituteViewModel} from "../../../../Typings/viewModels/InstituteViewModel";
import {CafedraViewModel} from "../../../../Typings/viewModels/CafedraViewModel";
import {DirectionViewModel} from "../../../../Typings/viewModels/DirectionViewModel";
import {observer} from "mobx-react";
import {StudentsQueryReadModel} from "../../../../Typings/readModels/StudentsQueryReadModel";
import {UserRole} from "../../../../Typings/enums/UserRole";
import AddOrUpdateInstituteEntityWindow
    from "../../../Admin/InstituteEntityCreationOrEdition/AddOrUpdateInstituteEntityWindow";
import {InstituteEntityType} from "../../../../consts/InstituteEntity";

class IFiltersProps {
    store: RootStore;
    updateFilters: any;
}

@observer
class Filters extends Component<IFiltersProps> {
    isDegreeOpen: boolean;
    isInstituteOpen: boolean;
    isCourseOpen: boolean;
    isCafedraOpen: boolean;
    isDirectionOpen: boolean;
    isGroupOpen: boolean;
    currentDegrees: DegreeViewModel[] = new Array<DegreeViewModel>();
    currentCourses: CourseViewModel[] = new Array<CourseViewModel>();
    currentGroups: GroupViewModel[] = new Array<GroupViewModel>();
    currentInstitutes: InstituteViewModel[] = new Array<InstituteViewModel>();
    currentCafedras: CafedraViewModel[] = new Array<CafedraViewModel>();
    currentDirections: DirectionViewModel[] = new Array<DirectionViewModel>();
    update: boolean;
    currentDegree: DegreeViewModel = new DegreeViewModel();
    currentGroup: GroupViewModel = new GroupViewModel();
    currentInstitute: InstituteViewModel = new InstituteViewModel();
    currentCourse: CourseViewModel = new CourseViewModel();
    currentCafedra: CafedraViewModel = new CafedraViewModel();
    currentDirection: DirectionViewModel = new DirectionViewModel();
    addOrUpdateEntity: boolean;

    constructor(props: IFiltersProps) {
        super(props);
        makeObservable(this, {
            isDegreeOpen: observable,
            isInstituteOpen: observable,
            isCourseOpen: observable,
            isCafedraOpen: observable,
            isDirectionOpen: observable,
            isGroupOpen: observable,
            currentDegrees: observable,
            currentCourses: observable,
            currentGroups: observable,
            currentInstitutes: observable,
            currentDirections: observable,
            currentCafedras: observable,
            update: observable,
            currentDegree: observable,
            currentGroup: observable,
            currentInstitute: observable,
            currentCourse: observable,
            currentCafedra: observable,
            currentDirection: observable,
            addOrUpdateEntity: observable,
        });
        this.setInitialData();
    }

    setInitialData() {
        let cafedras = this.props.store.instituteDetailsStore.cafedras;
        let groups = this.props.store.instituteDetailsStore.groups;
        let institutes = this.props.store.instituteDetailsStore.institutes;
        let directions = this.props.store.instituteDetailsStore.directions;
        let degrees = this.props.store.instituteDetailsStore.degrees;
        let courses = this.props.store.instituteDetailsStore.courses;
        this.currentCafedras = cafedras;
        this.currentGroups = groups;
        this.currentInstitutes = institutes;
        this.currentDirections = directions;
        this.currentDegrees = degrees;
        this.currentCourses = courses;
        this.currentCourse = courses[0] === undefined ? new CourseViewModel() : courses[0];
        this.currentDegree = degrees[0] === undefined ? new DegreeViewModel() : degrees[0];
        this.currentGroup = groups[0] === undefined ? new GroupViewModel() : groups[0];
        this.currentDirection = directions[0] === undefined ? new DirectionViewModel() : directions[0];
        this.currentCafedra = cafedras[0] === undefined ? new CafedraViewModel() : cafedras[0];
        this.currentInstitute = institutes[0] === undefined ? new InstituteViewModel() : institutes[0];
    }

    renderDropdownToggle(instituteEntity: InstituteEntityType) {
        let name = "";
        if(instituteEntity === InstituteEntityType.Degree) {
            name = this.currentDegree.name;
        } else if(instituteEntity === InstituteEntityType.Cafedra) {
            name = this.currentCafedra.name;
        } else if(instituteEntity === InstituteEntityType.Course) {
            name = this.currentCourse.name;
        } else if(instituteEntity === InstituteEntityType.Direction) {
            name = this.currentDirection.name;
        } else if(instituteEntity === InstituteEntityType.Institute) {
            name = this.currentInstitute.name;
        } else if(instituteEntity === InstituteEntityType.Group) {
            name = this.currentGroup.name;
        }
        name="ты горишь";
        return (
            <DropdownToggle caret outline className="filterButton">
                {name}
            </DropdownToggle>
        );
    }

    renderDegreeDropdown(degrees: DegreeViewModel[]) {
        return(
            <ButtonDropdown isOpen={this.isDegreeOpen} onClick={() => this.dropdownToggle(InstituteEntityType.Degree)} style={{width: "90%"}} className="buttonDropdown">
                {this.renderDropdownToggle(InstituteEntityType.Degree)}
                <DropdownMenu className="dropdownMenu">
                    {degrees.map(degree => {
                        return (
                            <DropdownItem
                                key={degree.id.toString()}
                                onClick={() => this.chooseFilter(InstituteEntityType.Degree, degree)}>
                                {degree.name}
                            </DropdownItem>
                        );
                    })}
                </DropdownMenu>
            </ButtonDropdown>
        );
    }

    renderAddOrUpdateButton() {
        if(this.props.store.userStore.currentUser.role === UserRole.Admin) {
            //todo: потом сюда
        }
        return (
            <DropdownItem
                onClick={() => this.addOrUpdateEntityToggle()}>
                <i className="fa fa-plus fa-3x" />
            </DropdownItem>
        )
    }

    renderInstituteDropdown(institutes: InstituteViewModel[]) {
        return(
            <ButtonDropdown isOpen={this.isInstituteOpen} onClick={() => this.dropdownToggle(InstituteEntityType.Institute)} style={{width: "90%"}}>
                {this.renderDropdownToggle(InstituteEntityType.Institute)}
                <DropdownMenu>
                    {institutes.map(institute => {
                        return (
                            <DropdownItem
                                key={institute.id.toString()}
                                onClick={() => this.chooseFilter(InstituteEntityType.Institute, institute)}>
                                {institute.name}
                            </DropdownItem>
                        );
                    })}
                </DropdownMenu>
            </ButtonDropdown>
        );
    }

    renderCafedraDropdown(cafedras: CafedraViewModel[]) {
        return(
            <ButtonDropdown isOpen={this.isCafedraOpen} onClick={() => this.dropdownToggle(InstituteEntityType.Cafedra)} style={{width: "90%"}}>
                {this.renderDropdownToggle(InstituteEntityType.Cafedra)}
                <DropdownMenu>
                    {cafedras.map(cafedra => {
                        return (
                            <DropdownItem
                                key={cafedra.id.toString()}
                                onClick={() => this.chooseFilter(InstituteEntityType.Cafedra, cafedra)}>
                                {cafedra.name}
                            </DropdownItem>
                        )
                    })}
                </DropdownMenu>
            </ButtonDropdown>
        );
    }

    renderDirectionDropdown(directions: DirectionViewModel[]) {
        return(
            <ButtonDropdown isOpen={this.isDirectionOpen} onClick={() => this.dropdownToggle(InstituteEntityType.Direction)} style={{width: "90%"}}>
                {this.renderDropdownToggle(InstituteEntityType.Direction)}
                <DropdownMenu>
                    {directions.map(direction => {
                        return (
                            <DropdownItem
                                key={direction.id.toString()}
                                onClick={() => this.chooseFilter(InstituteEntityType.Direction, direction)}>
                                {direction.name}
                            </DropdownItem>
                        );
                    })}
                </DropdownMenu>
            </ButtonDropdown>
        );
    }

    renderGroupsDropdown(groups: GroupViewModel[]) {
        return(
            <ButtonDropdown isOpen={this.isGroupOpen} onClick={() => this.dropdownToggle(InstituteEntityType.Group)} style={{width: "90%"}}>
                {this.renderDropdownToggle(InstituteEntityType.Group)}
                <DropdownMenu>
                    {groups.map(group => {
                        return (
                            <DropdownItem
                                key={group.id.toString()}
                                onClick={() => this.chooseFilter(InstituteEntityType.Group, group)}>
                                {group.name}
                            </DropdownItem>
                        );
                    })}
                </DropdownMenu>
            </ButtonDropdown>
        );
    }

    renderCoursesDropdown(courses: CourseViewModel[]) {
        return(
            <ButtonDropdown isOpen={this.isCourseOpen} onClick={() => this.dropdownToggle(InstituteEntityType.Course)} style={{width: "90%"}}>
                {this.renderDropdownToggle(InstituteEntityType.Course)}
                <DropdownMenu>
                    {courses.map(course => {
                        return (
                            <DropdownItem
                                key={course.id.toString()}
                                onClick={() => this.chooseFilter(InstituteEntityType.Course, course)}>
                                {course.name}
                            </DropdownItem>
                        );
                    })}
                </DropdownMenu>
            </ButtonDropdown>
        );
    }
    
    renderFilters(update: boolean) {
        return(
            <>
                <div className="col-lg-2 col-sm-6 col-xs-12 text-center">
                    {this.renderCoursesDropdown(this.currentCourses)}
                </div>
                <div className="col-lg-2 col-sm-6 col-xs-12 text-center">
                    {this.renderDegreeDropdown(this.currentDegrees)}
                </div>
                <div className="col-lg-2 col-sm-6 col-xs-12 text-center">
                    {this.renderInstituteDropdown(this.currentInstitutes)}
                </div>
                <div className="col-lg-2 col-sm-6 col-xs-12 text-center">
                    {this.renderCafedraDropdown(this.currentCafedras)}
                </div>
                <div className="col-lg-2 col-sm-6 col-xs-12 text-center">
                    {this.renderDirectionDropdown(this.currentDirections)}
                </div>
                <div className="col-lg-2 col-sm-6 col-xs-12 text-center">
                    {this.renderGroupsDropdown(this.currentGroups)}
                </div>
            </>
        );
    }

    render() {
        return(
            <>
                <div className="row justify-content-center" style={{marginTop: "10px"}}>
                    {this.renderFilters(this.update)}
                </div>
                <div className="row justify-content-start" style={{marginTop: "10px"}}>
                    {this.renderAddOrUpdateButton()}
                </div>
                {this.addOrUpdateEntity && <AddOrUpdateInstituteEntityWindow instituteStore={this.props.store.instituteDetailsStore} toggle={this.addOrUpdateEntityToggle}/>}
            </>
        );
    }

    dropdownToggle(instituteEntity: InstituteEntityType) {
        if(instituteEntity === InstituteEntityType.Degree) {
            this.isDegreeOpen = !this.isDegreeOpen;
        } else if(instituteEntity === InstituteEntityType.Cafedra) {
            this.isCafedraOpen = !this.isCafedraOpen;
        } else if(instituteEntity === InstituteEntityType.Course) {
            this.isCourseOpen = !this.isCourseOpen;
        } else if(instituteEntity === InstituteEntityType.Direction) {
            this.isDirectionOpen = !this.isDirectionOpen;
        } else if(instituteEntity === InstituteEntityType.Institute) {
            this.isInstituteOpen = !this.isInstituteOpen;
        } else if(instituteEntity === InstituteEntityType.Group) {
            this.isGroupOpen = !this.isGroupOpen;
        }
    }

    chooseFilter(instituteEntity: InstituteEntityType, filter: any) {
        if(instituteEntity === InstituteEntityType.Degree) {
            this.currentDegree = filter;
            let courses = this.currentDegree.courses;
            this.currentCourses = courses;
            this.currentCourse = courses[0];
        } else if(instituteEntity === InstituteEntityType.Cafedra) {
            this.currentCafedra = filter;
            this.currentCourse = this.props.store.instituteDetailsStore.courses.filter(c => c.id === filter.instituteId)[0];
            let directions = this.props.store.instituteDetailsStore.directions.filter(d => d.cafedraId === filter.id);
            this.currentDirections = directions;
            this.currentDirection = directions[0];
            let groups = this.props.store.instituteDetailsStore.groups
                .filter(g => g.directionId in (directions.map(c => { return c.id })))
                .filter(g => g.courseId = this.currentCourse.id);
            this.currentGroup = groups[0];
            this.currentGroups = groups;
        } else if(instituteEntity === InstituteEntityType.Course) {
            this.currentCourse = filter;
        } else if(instituteEntity === InstituteEntityType.Direction) {
            this.currentDirection = filter;
            let cafedra = this.props.store.instituteDetailsStore.cafedras.filter(c => c.id === filter.cafedraId)[0];
            let institute = this.props.store.instituteDetailsStore.institutes.filter(c => c.id === cafedra.instituteId)[0];
            this.currentCafedra = cafedra;
            this.currentInstitute = institute;
            let groups = this.props.store.instituteDetailsStore.groups
                .filter(g => g.directionId === filter.id)
                .filter(g => g.courseId === this.currentCourse.id);
            this.currentGroup = groups[0];
            this.currentGroups = groups;
        } else if(instituteEntity === InstituteEntityType.Institute) {
            this.currentInstitute = filter;
            let cafedras = this.props.store.instituteDetailsStore.cafedras.filter(t => t.instituteId === filter.id);
            this.currentCafedras = cafedras;
            this.currentCafedra = cafedras[0];
            let directions = this.props.store.instituteDetailsStore.directions.filter(d => d.cafedraId in (cafedras.map(c => { return c.id })));
            this.currentDirections = directions;
            this.currentDirection = directions[0];
            let groups = this.props.store.instituteDetailsStore.groups
                .filter(g => g.directionId in (directions.map(c => { return c.id })))
                .filter(g => g.courseId = this.currentCourse.id);
            this.currentGroup = groups[0];
            this.currentGroups = groups;
        } else if(instituteEntity === InstituteEntityType.Group) {
            let direction = this.props.store.instituteDetailsStore.directions.filter(c => c.id === filter.directionId)[0];
            let cafedra = this.props.store.instituteDetailsStore.cafedras.filter(c => c.id === direction.cafedraId)[0];
            let institute = this.props.store.instituteDetailsStore.institutes.filter(c => c.id === cafedra.instituteId)[0];
            let course = this.props.store.instituteDetailsStore.courses.filter(c => c.id === filter.courseId)[0];
            this.currentDirection = direction;
            this.currentCafedra = cafedra;
            this.currentInstitute = institute;
            this.currentCourse = course;
        }
        this.update = !this.update;
        this.updateFilters();
    }
    
    updateFilters() {
        let query = new StudentsQueryReadModel();
        query.instituteId = this.currentInstitute.id;
        query.groupId = this.currentGroup.id;
        query.cafedraId = this.currentCafedra.id;
        query.courseId = this.currentCourse.id;
        query.degreeId = this.currentDegree.id;
        query.directionId = this.currentDirection.id;
        this.props.updateFilters(query);
    }

    addOrUpdateEntityToggle() {
        this.addOrUpdateEntity = !this.addOrUpdateEntity;
    }
}

export default Filters;