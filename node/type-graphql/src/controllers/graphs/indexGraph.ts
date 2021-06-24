import { buildSchema } from "type-graphql";
import { ActorResolver } from "./actorResolver";
import { DramaResolver } from "./dramaResolver";

export class IndexGraph {
  schema: any

  /**
   *
   */
  constructor() {
    this.schema = buildSchema({
      resolvers: [
        ActorResolver,
        DramaResolver,
      ],
    });
  }


}