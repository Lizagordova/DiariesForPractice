import { WarningType } from "../consts/WarningType";
import { Alert } from "reactstrap";
import React from "react";

export function warningTypeRenderer(warningType: WarningType) {
    if(warningType === WarningType.Saved) {
        return (
            <Alert color="success">Данные успешно сохранены!</Alert>
        );
    } else if(warningType === WarningType.NotSaved) {
        return (
            <Alert color="danger">Что-то пошло не так, и данные не сохранились</Alert>
        );
    } else if(warningType === WarningType.Removed) {
        return (
            <Alert color="success">Данные успешно удалены!</Alert>
        );
    } else if(warningType === WarningType.NotRemoved) {
        return (
            <Alert color="danger">Что-то пошло не так, и данные не удалось удалить"</Alert>
        );
    }
}