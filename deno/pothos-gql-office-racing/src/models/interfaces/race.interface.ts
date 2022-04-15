export interface IRace {
  id: string;
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
