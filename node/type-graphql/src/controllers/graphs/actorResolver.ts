import { StudiedActor } from "src/models/studiedActor";
import { Arg, Query, Resolver } from "type-graphql";

@Resolver(StudiedActor)
export class ActorResolver {

  @Query(returns => StudiedActor)
  async recipe(@Arg("id") id: string): Promise<StudiedActor> {
    return {
      id: "36cb7641-300c-4631-9c9b-b2fbaf50fca1",
      dbname: "actor-A",
      name: "AAA",
      description: "A",
      talents: ["singing", "dancing", "basketball"],
    };
  }

}