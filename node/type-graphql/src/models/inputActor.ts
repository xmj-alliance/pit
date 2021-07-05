import { InputType, Field } from "type-graphql";
import { IInputActor, IInputActorCondition } from "./interfaces/actor.interface";

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
export class InputActorCondition implements IInputActorCondition {
  @Field(type => [String])
  dbnames: string[];
}