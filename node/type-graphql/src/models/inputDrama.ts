import { InputType, Field } from "type-graphql";
import { IInputDrama, IDramaQueryCondition, IDramaQuerySelector } from "./interfaces/drama.interface";

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
export class DramaQuerySelector implements IDramaQuerySelector {

  @Field({ nullable: true })
  id?: string;

  @Field({ nullable: true })
  dbname?: string;

}

@InputType()
export class DramaQueryCondition implements IDramaQueryCondition {
  @Field(type => [String])
  dbnames: string[];
}