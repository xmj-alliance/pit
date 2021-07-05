import { InputDramaCondition } from "src/models/inputDrama";
import { IStoredDrama } from "src/models/interfaces/drama.interface";
import { StudiedDrama } from "src/models/studiedDrama";
import { ActorService } from "src/services/actorService";
import { DramaService } from "src/services/dramaService";
import { Arg, FieldResolver, Query, Resolver, ResolverInterface, Root } from "type-graphql";

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

  @Query(returns => StudiedDrama)
  async drama(@Arg("dbname") dbname: string) {

    const drama = await this.dramaService.getSingle(dbname);

    if (drama) {

      return drama;
    }

    return {};
  }

  @Query(returns => StudiedDrama)
  async dramas(@Arg("condition") condition: InputDramaCondition) {

    const dramas = await this.dramaService.getList(condition.dbnames);

    return dramas;
  }

}