import { InputActorCondition } from "src/models/inputActor";
import { StudiedActor } from "src/models/studiedActor";
import { ActorService } from "src/services/actorService";
import { Arg, Query, Resolver } from "type-graphql";

@Resolver(of => StudiedActor)
export class ActorResolver {

  private readonly actorService: ActorService;

  /**
   *
   */
  constructor() {
    this.actorService = new ActorService();
  }

  @Query(returns => StudiedActor)
  async actor(@Arg("dbname") dbname: string): Promise<StudiedActor> {

    const actor = await this.actorService.getSingle(dbname);

    if (actor) {
      return actor;
    }

    return {} as StudiedActor;
  }

  @Query(returns => StudiedActor)
  async actors(@Arg("condition") condition: InputActorCondition): Promise<StudiedActor[]> {

    const actors = await this.actorService.getList(condition.dbnames);

    return actors;
  }

}