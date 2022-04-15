import { IBaseObject } from "./base.interface.ts";

export interface IVehicle extends IBaseObject {
  name: string;
  description: string;
}

export interface IInputVehicle {
  name?: string;
  description?: string;
}
