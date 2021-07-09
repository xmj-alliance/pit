import { ObjectType, Field, ID } from "type-graphql";
import { IStoredActor } from "./interfaces/actor.interface";

@ObjectType("Actor")
export class StoredActor implements IStoredActor {

  @Field(type => ID)
  id: string;
  
  @Field()
  dbname: string;

  @Field(type => String, { nullable: true })
  name?: string | null;

  @Field(type => String, { nullable: true })
  description?: string | null;

  @Field(type => [String], { nullable: true })
  talents?: string[] | null;
}