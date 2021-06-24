import { ApolloServer, Config } from "apollo-server-koa";
import { GraphQLSchema } from "graphql";
import { buildSchemaSync } from "type-graphql";
import { ActorResolver } from "./actorResolver";
import { DramaResolver } from "./dramaResolver";

export class IndexGraph {
  
  private schema: GraphQLSchema;
  private readonly apolloConfig = {} as Config;
  public readonly server: ApolloServer;
  
  /**
   *
   */
  constructor() {

    this.schema = buildSchemaSync({
      resolvers: [
        ActorResolver,
        DramaResolver,
      ],
    });

    const env = process.env.NODE_ENV;
    const isDevMode = (env && env.toLowerCase() === "development") || false;

    this.apolloConfig = {
      schema: this.schema,
      // enable playground only during development
      introspection: isDevMode,
      playground: isDevMode,
    }

    this.server = new ApolloServer(this.apolloConfig);

  }


}