import { InputType, Field } from "type-graphql";
import { IInputActor, IActorQueryCondition, IActorQuerySelector, IStoredActor } from "./interfaces/actor.interface";

@InputType()
export class InputActor implements IInputActor {

  @Field()
  dbname: string;

  @Field({ nullable: true })
  name?: string;

  @Field({ nullable: true })
  description?: string;

  @Field(type => [String], { nullable: true })
  talents?: string[];

}

@InputType()
export class ActorQuerySelector implements IActorQuerySelector {

  @Field({ nullable: true })
  id?: string;

  @Field({ nullable: true })
  dbname?: string;

}

@InputType()
export class ActorQueryCondition implements IActorQueryCondition {
  @Field(type => [String])
  dbnames: string[];
}

@InputType()
export class ActorUpdateToken implements Partial<IStoredActor> {

  @Field({ nullable: true })
  dbname?: string;

  @Field({ nullable: true })
  name?: string;

  @Field({ nullable: true })
  description?: string;

  @Field(type => [String], { nullable: true })
  talents?: string[];

}