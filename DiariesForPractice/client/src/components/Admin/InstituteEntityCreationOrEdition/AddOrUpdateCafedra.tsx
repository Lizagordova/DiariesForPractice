import React, { Component } from "react";
import { observer } from "mobx-react";
import { makeObservable, observable } from "mobx";
import { CafedraToHandle } from "./Models/CafedraToHandle";
import { CafedraViewModel } from "../../../Typings/viewModels/CafedraViewModel";
import { Button, Input, Modal } from "reactstrap";
import AddOrUpdateDirection from "./AddOrUpdateDirection";
import { DirectionViewModel } from "../../../Typings/viewModels/DirectionViewModel";
import { DirectionToHandle } from "./Models/DirectionToHandle";

class IAddOrUpdateCafedraProps {
    cafedra: CafedraToHandle;
    updateCafedra: any;
    isNew: boolean;
}

@observer
class AddOrUpdateCafedra extends Component<IAddOrUpdateCafedraProps> {
    cafedra: CafedraViewModel = new CafedraViewModel();
    inputModalOpen: boolean;

    constructor(props: IAddOrUpdateCafedraProps) {
        super(props);
        makeObservable(this, {
            cafedra: observable,
            inputModalOpen: observable
        });
        this.setDataFromProps();
    }

    componentDidUpdate(prevProps: Readonly<IAddOrUpdateCafedraProps>, prevState: Readonly<{}>, snapshot?: any): void {
        if(prevProps !== this.props) {
            this.setDataFromProps();
        }
    }

    setDataFromProps() {
        this.cafedra = this.props.cafedra.cafedra;
    }

    renderCafedraInputModal() {
        return (
            <Modal isOpen={this.inputModalOpen} toggle={this.inputModalOpenToggle}>
                {this.renderCafedraInput()}
                {this.renderSaveCafedraButton()}
            </Modal>
        );
    }

    renderSaveCafedraButton() {
        return (
            <div className="row justify-content-center">
                <Button
                    onClick={() => this.inputModalOpenToggle()}>
                    Сохранить
                </Button>
            </div>
        );
    }

    renderCafedraInput() {
        return (
            <div className="row justify-content-center">
                <Input
                    style={{width: "80%"}}
                    value={this.cafedra.name}
                    placeholder="Название кафедры"
                    onChange={(e) => this.cafedraNameInput(e)}/>
            </div>
        );
    }

    renderDirectionOptions(cafedra: CafedraViewModel) {
        let directions = cafedra.directions;
        return (
            <div className="row justify-content-center">
                {directions.map((direction, index) => {
                    let directionToHandle = this.getDirectionToHandle(direction, index);
                    return (
                        <AddOrUpdateDirection direction={directionToHandle} updateDirection={this.updateDirection} isNew={false} />
                    );
                })}
                <AddOrUpdateDirection direction={new DirectionToHandle()} updateDirection={this.updateDirection} isNew={true} />
            </div>
        );
    }

    renderCafedraName(cafedra: CafedraViewModel) {
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
                    {cafedra.name}
                </Button>
            );
        }
    }

    render() {
        return (
            <>
                {!this.inputModalOpen && this.renderCafedraInputModal()}
                {this.renderCafedraName(this.cafedra)}
                {this.renderDirectionOptions(this.cafedra)}
            </>
        );
    }

    cafedraNameInput(event: React.FormEvent<HTMLInputElement>) {
        this.cafedra.name = event.currentTarget.value;
        this.props.updateCafedra(this.cafedra, this.props.cafedra.index);//todo: здесь возможно запаздание
    }

    updateDirection(direction: DirectionViewModel, index: number) {
        this.cafedra.directions[index] = direction;
    }

    inputModalOpenToggle() {
        this.inputModalOpen = !this.inputModalOpen;
    }

    getDirectionToHandle(direction: DirectionViewModel, index: number): DirectionToHandle {
        let directionToHandle = new DirectionToHandle();
        directionToHandle.direction = direction;
        directionToHandle.index = index;

        return directionToHandle;
    }
}

export default AddOrUpdateCafedra;