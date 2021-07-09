import { CUDMessage } from "src/models/cudMessage";
import { DramaQueryCondition, DramaQuerySelector, DramaUpdateToken, InputDrama } from "src/models/inputDrama";
import { IStoredDrama } from "src/models/interfaces/drama.interface";
import { StoredDrama } from "src/models/storedDrama";

import { ActorService } from "src/services/actorService";
import { DramaService } from "src/services/dramaService";
import { Arg, FieldResolver, Mutation, Query, Resolver, Root } from "type-graphql";

@Resolver(of => StoredDrama)
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
    if (!drama.actors || drama.actors.length <= 0) {
      return [];
    }
    const actors = await this.actorService.getList(drama.actors);
    return actors;
  }

  @Query(returns => StoredDrama, {nullable: true})
  async drama(@Arg("selector") selector: DramaQuerySelector): Promise<StoredDrama | null> {
    const drama = await this.dramaService.getSingle(selector);
    return drama as StoredDrama | null;
  }

  @Query(returns => [StoredDrama])
  async dramas(@Arg("condition", {nullable: true}) condition?: DramaQueryCondition): Promise<StoredDrama[]> {

    const findCondition = condition || {dbnames: []}

    const dramas = await this.dramaService.getList(findCondition.dbnames);

    return dramas;
  }

  @Mutation(returns => CUDMessage)
  async addDrama(@Arg("newItem") newItem: InputDrama): Promise<CUDMessage> {
    const createMessage = await this.dramaService.addSingle(newItem);
    return createMessage;
  }

  @Mutation(returns => CUDMessage)
  async updateDrama(@Arg("dbname") dbname: string, @Arg("token") token: DramaUpdateToken): Promise<CUDMessage> {
    const updateMessage = await this.dramaService.updateSingle(dbname, token);
    return updateMessage;
  }

  @Mutation(returns => CUDMessage)
  async deleteDrama(@Arg("dbname") dbname: string): Promise<CUDMessage> {
    const deleteMessage = await this.dramaService.deleteSingle(dbname);
    return deleteMessage;
  }

}