//     This code was generated by a Reinforced.Typings tool. 
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.

import { IInstituteEntity } from '../interfaces/IInstituteEntity';
import { DirectionViewModel } from './DirectionViewModel';

export class CafedraViewModel implements IInstituteEntity
{
	public id: number;
	public name: string;
	public instituteId: number;
	public directions: DirectionViewModel[] = [];
}