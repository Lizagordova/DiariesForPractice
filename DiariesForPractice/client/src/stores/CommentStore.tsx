import { makeObservable, observable } from "mobx";
import {CommentReadModel} from "../Typings/readModels/CommentReadModel";
import {CommentGroupReadModel} from "../Typings/readModels/CommentGroupReadModel";
import {CommentGroupViewModel} from "../Typings/viewModels/CommentGroupViewModel";

class CommentStore {
    constructor() {
        makeObservable(this, {
        });
    }

    async addOrUpdateComment(comment: CommentReadModel): Promise<number> {
        const response = await fetch("/addorupdatecomment", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                comment: comment
            })
        });
        let id = 0;
        if(response.status === 200) {
            id = await response.json();
        }

        return id;
    }

    async addOrUpdateCommentGroup(commentGroup: CommentGroupReadModel): Promise<number> {
        const response = await fetch("/addorupdatecommentgroup", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                commentGroup: commentGroup
            })
        });
        let id = 0;
        if(response.status === 200) {
            id = await response.json();
        }

        return id;
    }

    async removeComment(id: number): Promise<number> {
        const response = await fetch("/removecomment", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                id: id
            })
        });

        return response.status;
    }

    async getCommentGroup(commentGroup: CommentGroupReadModel): Promise<CommentGroupViewModel> {
        const response = await fetch("/getcommentgroup", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
               commentGroup //todo: хз можно ли так
            })
        });
        let perceivedCommentGroup = new CommentGroupViewModel();
        if(response.status === 200) {
            perceivedCommentGroup = await response.json();
        } else {
            perceivedCommentGroup.commentedEntityId = commentGroup.commentedEntityId;
            perceivedCommentGroup.commentedEntityType = commentGroup.commentedEntityType;
            perceivedCommentGroup.userId = commentGroup.userId;
        }

        return perceivedCommentGroup;
    }
}

export default CommentStore;