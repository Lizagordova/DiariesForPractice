import React, { Component } from "react";
import InstituteDetailsStore from "../../../stores/InstituteDetailsStore";
import { observer } from "mobx-react";
import { Button, Input, Modal, ModalHeader, ModalBody, Alert } from "reactstrap";
import { InstituteViewModel } from "../../../Typings/viewModels/InstituteViewModel";
import { makeObservable, observable } from "mobx";
import { CafedraViewModel } from "../../../Typings/viewModels/CafedraViewModel";
import AddOrUpdateCafedra from "./AddOrUpdateCafedra";
import { CafedraToHandle } from "./Models/CafedraToHandle";
import {mapToInstituteReadModel} from "../../../functions/mapper";

class IAddOrUpdateInstituteEntityWindowProps {
    instituteStore: InstituteDetailsStore;
    toggle: any;
}

@observer
class AddOrUpdateInstituteEntityWindow extends Component<IAddOrUpdateInstituteEntityWindowProps> {
    institute: InstituteViewModel = new InstituteViewModel();
    update: boolean;
    saved: boolean;
    notSaved: boolean;

    constructor(props: IAddOrUpdateInstituteEntityWindowProps) {
        super(props);
        makeObservable(this, {
            institute: observable,
            update: observable,
            saved: observable,
            notSaved: observable,
        });
    }

    renderWarnings() {
        setTimeout(() => {
            this.notSaved = false;
            this.saved = false;
        }, 6000);
        return (
            <>
                {this.saved && <Alert color="success">Всё удачно сохранилось!</Alert>}
                {this.notSaved && <Alert color="success">Что-то пошло не так, и не удалось сохранить изменения</Alert>}
            </>
        );
    }
    
    renderCreationWindow() {
        return(
            <Modal toggle={() => this.handleToggle()} isOpen={true} size="lg">
                <ModalHeader
                    toggle={() => this.handleToggle()}
                    cssModule={{'modal-title': 'w-100 text-center'}}
                >
                    Сущность в университете
                </ModalHeader>
                {this.renderWarnings()}
                <ModalBody>
                    {this.renderBody()}
                </ModalBody>
                <div className="row justify-content-center">
                    {this.renderSaveButton()}
                </div>
            </Modal>
        );
    }

    renderSaveButton() {
        return (
            <Button
                style={{backgroundColor: "black", color: "white"}}
                onClick={() => this.handleSave()}>
                Сохранить
            </Button>
        );
    }

    renderInstituteOption() {//todo: сделать выпадающий список + значок "добавить"
        return (
            <div className="row justify-content-center">
                <Button>
                    
                </Button>
            </div>
        );
    }

    renderCafedrasOptions(institute: InstituteViewModel) {//todo: выпадающий список сделать
        let cafedras = institute.cafedras;
        return (
            <div className="row justify-content-center">
                {cafedras.map((cafedra, index) => {
                    let cafedraToHandle = this.getCafedraToHandle(cafedra, index);
                    return (
                        <AddOrUpdateCafedra cafedra={cafedraToHandle} updateCafedra={this.updateCafedra} isNew={false}/>
                    );
                })}
                <AddOrUpdateCafedra cafedra={new CafedraToHandle()} updateCafedra={this.updateCafedra} isNew={true} />
            </div>
        );
    }

    renderBody() {
        return (
            <>
                {this.renderInstituteOption()}
                {this.renderCafedrasOptions(this.institute)}
            </>
        );
    }

    render() {
        return (
            <>
                {this.renderCreationWindow()}
            </>
        );
    }

    handleToggle() {
        let result = window.confirm(`Вы уверены, что хотите закрыть это окно?`);
        if(result) {
            this.props.toggle();
        }
    }

    handleSave() {
        let checked = true;
        //todo: check everything
        if(checked) {
            this.save();
        }
    }

    save() {
        let institute = mapToInstituteReadModel(this.institute);
        this.props.instituteStore.addOrUpdateInstitute(institute)
            .then((status) => {
                this.saved = status === 200;
                this.notSaved = status !== 200;
            });
    }

    getCafedraToHandle(cafedra: CafedraViewModel, index: number): CafedraToHandle {
        let cafedraToHandle = new CafedraToHandle();
        cafedraToHandle.cafedra = cafedra;
        cafedraToHandle.index = index;

       return cafedraToHandle;
    }

    updateCafedra(cafedra: CafedraViewModel, index: number) {
        this.institute.cafedras[index] = cafedra;
    }
}

export default AddOrUpdateInstituteEntityWindow;