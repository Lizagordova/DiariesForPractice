//     This code was generated by a Reinforced.Typings tool. 
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.

import { CommentReadModel } from './CommentReadModel';

export class CommentGroupReadModel
{
	public id: number;
	public commentedEntityType: number;
	public commentedEntityId: number;
	public userId: number;
	public comment: CommentReadModel;
}
