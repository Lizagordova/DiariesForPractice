import React, { Component } from "react";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import { DirectionToHandle } from "./Models/DirectionToHandle";
import { DirectionViewModel } from "../../../Typings/viewModels/DirectionViewModel";
import { Button, Input, Modal } from "reactstrap";
import {CafedraViewModel} from "../../../Typings/viewModels/CafedraViewModel";
import AddOrUpdateGroup from "./AddOrUpdateGroup";
import {GroupToHandle} from "./Models/GroupToHandle";
import {GroupViewModel} from "../../../Typings/viewModels/GroupViewModel";

class IAddOrUpdateDirectionProps {
    direction: DirectionToHandle;
    updateDirection: any;
    isNew: boolean;
}

@observer
class AddOrUpdateDirection extends Component<IAddOrUpdateDirectionProps> {
    direction: DirectionViewModel;
    inputModalOpen: boolean;

    constructor(props: IAddOrUpdateDirectionProps) {
        super(props);
        makeObservable(this, {
            direction: observable,
            inputModalOpen: observable
        });
        this.setDataFromProps();
    }

    componentDidUpdate(prevProps: Readonly<IAddOrUpdateDirectionProps>, prevState: Readonly<{}>, snapshot?: any): void {
        if(prevProps !== this.props) {
            this.setDataFromProps();
        }
    }

    setDataFromProps() {
        this.direction = this.props.direction.direction;
    }

    renderDirectionInput() {
        return (
            <div className="row justify-content-center">
                <Input
                    style={{width: "80%"}}
                    value={this.direction.name}
                    placeholder="Название кафедры"
                    onChange={(e) => this.directionNameInput(e)}/>
            </div>
        );
    }

    renderSaveDirectionButton() {
        return (
            <div className="row justify-content-center">
                <Button
                    onClick={() => this.inputModalOpenToggle()}>
                    Сохранить
                </Button>
            </div>
        );
    }

    renderDirectionInputModal() {
        return (
            <Modal isOpen={this.inputModalOpen} toggle={this.inputModalOpenToggle}>
                {this.renderDirectionInput()}
                {this.renderSaveDirectionButton()}
            </Modal>
        )
    }

    renderDirectionName(direction: DirectionViewModel) {
        if(this.props.isNew) {
            return (
                <Button
                    outline color="secondary"
                    className="instituteEntityButton"
                    onClick={() => this.inputModalOpenToggle()}>
                    <i className="fa fa-plus fa-3x" />
                </Button>
            );
        } else {
            return (
                <Button
                    outline color="secondary"
                    className="instituteEntityButton"
                    onClick={() => this.inputModalOpenToggle()}>
                    {direction.name}
                </Button>
            );
        }
    }

    renderGroupOptions(direction: DirectionViewModel) {
        let groups = direction.groups;
        return (
            <div className="row justify-content-center">
                {groups.map((group, index) => {
                    let groupToHandle = this.getGroupToHandle(group, index);
                    return (
                        <AddOrUpdateGroup groupToHandle={groupToHandle} updateGroup={this.updateGroup} isNew={false} />
                    );
                })}
                <AddOrUpdateGroup groupToHandle={new GroupToHandle()} updateGroup={this.updateGroup} isNew={true} />
            </div>
        );
    }

    render() {
        return (
            <>
                {!this.inputModalOpen && this.renderDirectionInputModal()}
                {this.renderDirectionName(this.direction)}
                {this.renderGroupOptions(this.direction)}
            </>
        );
    }

    inputModalOpenToggle() {
        this.inputModalOpen = !this.inputModalOpen;
    }

    directionNameInput(event: React.FormEvent<HTMLInputElement>) {
        this.direction.name = event.currentTarget.value;
        this.props.updateDirection(this.direction, this.props.direction.index);
    }

    getGroupToHandle(group: GroupViewModel, index: number): GroupToHandle {
        let groupToHandle = new GroupToHandle();
        groupToHandle.group = group;
        groupToHandle.index = index;

        return groupToHandle;
    }

    updateGroup() {
        
    }
}

export default AddOrUpdateDirection;