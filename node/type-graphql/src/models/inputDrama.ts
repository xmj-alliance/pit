import { InputType, Field } from "type-graphql";
import { IInputDrama, IInputDramaCondition } from "./interfaces/drama.interface";

@InputType()
export class InputDrama implements IInputDrama {

  @Field()
  dbname: string;

  @Field({ nullable: true })
  name?: string;

  @Field({ nullable: true })
  description?: string;

  @Field()
  genre: string;
  
  @Field(type => [String], { nullable: true })
  actors?: string[];

}

@InputType()
export class InputDramaCondition implements IInputDramaCondition {
  @Field(type => [String])
  dbnames: string[];
}