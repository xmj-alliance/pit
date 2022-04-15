import {
  IInputPlayer,
  IPlayer,
} from "src/models/interfaces/player.interface.ts";

export class PlayerService {
  private players: IPlayer[] = [];

  add = (newItems: IInputPlayer[]) => {
    const addingItems: IPlayer[] = [];

    for (const item of newItems) {
      const randomID = crypto.randomUUID();
      const addingItem: IPlayer = {
        id: randomID,
        name: item.name || `random-${randomID}`,
        description: item.description || `random-${randomID}`,
      };
      addingItems.push(addingItem);
    }

    this.players = this.players.concat(addingItems);

    return addingItems;
  };

  getByIDs = (searchIDs: string[]) => {
    return this.players.filter((ele) => searchIDs.includes(ele.id));
  };

  getAll = () => {
    return this.players;
  };

  search = (query: string) => {
    // do a whole search
    const findByIDResult = this.players.filter((ele) => ele.id.includes(query));
    const findByNameResult = this.players.filter((ele) =>
      ele.name.includes(query)
    );
    const findByDescriptionResult = this.players.filter((ele) =>
      ele.description.includes(query)
    );

    const resultCollection: IPlayer[][] = [
      findByIDResult,
      findByNameResult,
      findByDescriptionResult,
    ];

    // remove duplicate IDs
    const resultMap: { [id: string]: IPlayer } = {};

    for (const category of resultCollection) {
      for (const result of category) {
        if (!resultMap[result.id]) {
          resultMap[result.id] = result;
        }
      }
    }

    return Object.values(resultMap);
  };

  update = (changedItems: IPlayer[]) => {
    const updatedItems: IPlayer[] = [];

    for (const item of changedItems) {
      const existingItem = this.players.find((ele) => ele.id === item.id);
      if (!existingItem) {
        continue;
      }

      existingItem.name = item.name;
      existingItem.description = item.description;

      updatedItems.push(existingItem);
    }

    return updatedItems;
  };

  deleteByIDs = (searchIDs: string[]) => {
    let deletedItems: IPlayer[] = [];

    for (const id of searchIDs) {
      const existingItemIndex = this.players.findIndex((ele) => ele.id === id);
      if (existingItemIndex < 0) {
        continue;
      }
      const deletingItems = this.players.splice(existingItemIndex, 1);
      deletedItems = deletedItems.concat(deletingItems);
    }

    return deletedItems;
  };
}
