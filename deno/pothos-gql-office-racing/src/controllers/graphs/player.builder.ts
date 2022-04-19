import { Player } from "src/models/player.ts";
import { PothosQueryBuilder, PothosSchemaBuilder } from "./schemaBuilder.ts";

const applyPlayerObjectType = (builder: PothosSchemaBuilder) => {
  return builder.objectType(Player, {
    name: "Player",
    description: "player graph descr",
    fields: (t) => ({
      id: t.exposeString("id" as never),
      name: t.exposeString("name" as never),
      description: t.exposeString("description" as never),
    }),
  });
};

const buildPlayerQueryType = (t: PothosQueryBuilder) => {
  return {
    getPlayers: t.field({
      type: [Player],
      args: {
        ting: t.arg.string({ required: true }),
      },
      resolve: (parent, args) => [
        new Player({
          id: "test",
          name: args.ting,
          description: "test descr 3",
        }),
      ],
    }),
  };
};

export { applyPlayerObjectType, buildPlayerQueryType };
