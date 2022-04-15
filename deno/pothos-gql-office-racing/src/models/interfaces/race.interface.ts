import { IBaseObject } from "./base.interface.ts";

export interface IRace extends IBaseObject {
  date: Date;
  scene: string;
  /** IPlayer => IVehicle */
  racerMap: Map<string, string>;
}

export interface IInputRace {
  date?: Date;
  scene: string;
  /** IPlayer => IVehicle */
  racerMap: Map<string, string>;
}
