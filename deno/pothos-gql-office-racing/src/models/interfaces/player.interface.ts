import { IBaseObject } from "./base.interface.ts";

export interface IPlayer extends IBaseObject {
  name: string;
  description: string;
}

export interface IInputPlayer {
  name?: string;
  description?: string;
}
