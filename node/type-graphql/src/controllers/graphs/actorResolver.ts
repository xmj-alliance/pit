import { ActorQueryCondition, ActorQuerySelector } from "src/models/inputActor";
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

  @Query(returns => StudiedActor, {nullable: true})
  async actor(@Arg("selector") selector: ActorQuerySelector): Promise<StudiedActor | null> {

    return await this.actorService.getSingle(selector);

  }

  @Query(returns => [StudiedActor])
  async actors(@Arg("condition", {nullable: true}) condition?: ActorQueryCondition): Promise<StudiedActor[]> {

    const findCondition = condition || {dbnames: []}

    const actors = await this.actorService.getList(findCondition.dbnames);

    return actors;
  }

}