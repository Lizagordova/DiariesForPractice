//     This code was generated by a Reinforced.Typings tool. 
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.

import { IInstituteEntity } from '../interfaces/IInstituteEntity';
import { StudentViewModel } from './StudentViewModel';

export class GroupViewModel implements IInstituteEntity
{
	public id: number;
	public name: string;
	public directionId: number;
	public courseId: number;
	public students: StudentViewModel[] = [];
}