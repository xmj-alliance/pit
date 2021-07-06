import { DramaQueryCondition, DramaQuerySelector } from "src/models/inputDrama";
import { IStoredDrama } from "src/models/interfaces/drama.interface";
import { StudiedDrama } from "src/models/studiedDrama";
import { ActorService } from "src/services/actorService";
import { DramaService } from "src/services/dramaService";
import { Arg, FieldResolver, Query, Resolver, Root } from "type-graphql";

@Resolver(of => StudiedDrama)
export class DramaResolver {


  private readonly dramaService: DramaService;
  private readonly actorService: ActorService;

  /**
   *
   */
  constructor() {
    this.dramaService = new DramaService();
    this.actorService = new ActorService();
  }

  @FieldResolver()
  async actors(@Root() drama: IStoredDrama) {
    const actors = await this.actorService.getList(drama.actors);
    return actors;
  }

  @Query(returns => StudiedDrama, {nullable: true})
  async drama(@Arg("selector") selector: DramaQuerySelector) {

    return await this.dramaService.getSingle(selector);

  }

  @Query(returns => [StudiedDrama])
  async dramas(@Arg("condition", {nullable: true}) condition?: DramaQueryCondition) {

    const findCondition = condition || {dbnames: []}

    const dramas = await this.dramaService.getList(findCondition.dbnames);

    return dramas;
  }

}