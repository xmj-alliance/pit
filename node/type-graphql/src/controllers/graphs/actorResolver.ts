import { CUDMessage } from "src/models/cudMessage";
import { ActorQueryCondition, ActorQuerySelector, ActorUpdateToken, InputActor } from "src/models/inputActor";
import { StoredActor } from "src/models/storedActor";
import { ActorService } from "src/services/actorService";
import { Arg, Mutation, Query, Resolver } from "type-graphql";

@Resolver(of => StoredActor)
export class ActorResolver {

  private readonly actorService: ActorService;

  /**
   *
   */
  constructor() {
    this.actorService = new ActorService();
  }

  @Query(returns => StoredActor, {nullable: true})
  async actor(@Arg("selector") selector: ActorQuerySelector): Promise<StoredActor | null> {

    return await this.actorService.getSingle(selector);

  }

  @Query(returns => [StoredActor])
  async actors(@Arg("condition", {nullable: true}) condition?: ActorQueryCondition): Promise<StoredActor[]> {

    const findCondition = condition || {dbnames: []}

    const actors = await this.actorService.getList(findCondition.dbnames);

    return actors;
  }

  @Mutation(returns => CUDMessage)
  async addActor(@Arg("newItem") newItem: InputActor): Promise<CUDMessage> {
    const createMessage = await this.actorService.addSingle(newItem);
    return createMessage;
  }

  @Mutation(returns => CUDMessage)
  async updateActor(@Arg("dbname") dbname: string, @Arg("token") token: ActorUpdateToken): Promise<CUDMessage> {
    const updateMessage = await this.actorService.updateSingle(dbname, token);
    return updateMessage;
  }

  @Mutation(returns => CUDMessage)
  async deleteActor(@Arg("dbname") dbname: string): Promise<CUDMessage> {
    const deleteMessage = await this.actorService.deleteSingle(dbname);
    return deleteMessage;
  }

}