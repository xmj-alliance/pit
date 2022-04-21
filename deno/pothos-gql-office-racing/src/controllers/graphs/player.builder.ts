import { InputObjectRef, ObjectRef } from "@hayes/pothos";

import { Player } from "src/models/player.ts";
import { InputPlayer } from "src/models/inputPlayer.ts";
import { PlayerService } from "src/services/player.service.ts";
import {
  PothosMutationBuilder,
  PothosQueryBuilder,
  PothosSchemaBuilder,
} from "./schemaBuilder.ts";

export class PlayerGraphBuilder {
  private readonly playerService = new PlayerService();
  private readonly builder: PothosSchemaBuilder;

  private inputType: InputObjectRef<InputPlayer>;

  /** */
  constructor(
    _builder: PothosSchemaBuilder,
  ) {
    this.builder = _builder;
    this.applyPlayerObjectType();
    this.inputType = this.createPlayerInputType();
  }

  private applyPlayerObjectType = () => {
    return this.builder.objectType(Player, {
      name: "Player",
      description: "player graph descr",
      fields: (t) => ({
        id: t.exposeID("id" as never),
        name: t.exposeString("name" as never),
        description: t.exposeString("description" as never),
      }),
    });
  };

  private createPlayerInputType = () => {
    const inputRef = this.builder.inputRef<InputPlayer>("InputPlayer");

    return this.builder.inputType(inputRef, {
      description: "player graph descr",
      fields: (t) => ({
        name: t.string(),
        description: t.string(),
      }),
    });
  };

  buildPlayerQueryType = (t: PothosQueryBuilder) => {
    return {
      getPlayers: t.field({
        type: [Player],
        args: {
          ids: t.arg.stringList({ required: true }),
        },
        resolve: (parent, args) => this.playerService.getByIDs(args.ids),
      }),
    };
  };

  buildPlayerMutationType = (t: PothosMutationBuilder) => {
    return {
      addPlayers: t.field({
        type: [Player],
        args: {
          newItems: t.arg({ type: [this.inputType], required: true }),
        },
        resolve: (parent, args) => this.playerService.add(args.newItems),
      }),
    };
  };
}
