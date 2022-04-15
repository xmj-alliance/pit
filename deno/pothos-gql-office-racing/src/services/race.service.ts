import { IInputRace, IRace } from "src/models/interfaces/race.interface.ts";
import { MockCRUDService } from "./mockCrud.service.ts";

export class RaceService extends MockCRUDService<IRace> {
  add(newItems: IInputRace[]) {
    const addingItems: IRace[] = [];

    for (const item of newItems) {
      const randomID = crypto.randomUUID();
      const addingItem: IRace = {
        id: randomID,
        date: item.date || new Date(),
        scene: item.scene,
        racerMap: item.racerMap,
      };
      addingItems.push(addingItem);
    }

    super.add(addingItems);

    return addingItems;
  }

  search(query: string) {
    return super.search(
      query,
      ["id", "scene"],
    );
  }
}
