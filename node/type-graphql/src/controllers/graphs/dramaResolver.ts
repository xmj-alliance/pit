import { StudiedDrama } from "src/models/studiedDrama";
import { Arg, Query, Resolver } from "type-graphql";

@Resolver(StudiedDrama)
export class DramaResolver {

  @Query(returns => StudiedDrama)
  async drama(@Arg("id") id: string): Promise<StudiedDrama> {
    return {
      id: "c916257f-10d9-44e2-a38e-29101553b0d8",
      dbname: "drama-momoda",
      name: "Momoda",
      description: "Epic fantastic love story",
      genre: "genre-love",
      actors: []
    };
  }

}