import { IInputPlayer } from "./interfaces/player.interface.ts";

export class InputPlayer implements IInputPlayer {
  name?: string | null;
  description?: string | null;
  /** */
  constructor(_player: IInputPlayer) {
    this.name = _player.name;
    this.description = _player.description;
  }
}
