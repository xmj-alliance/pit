import { ObjectType, Field, ID } from "type-graphql";
import { IStudiedActor } from "./interfaces/studiedActor.interface";

@ObjectType("Actor")
export class StudiedActor implements IStudiedActor {

  @Field(type => ID)
  id: string;
  
  @Field()
  dbname: string;

  @Field({ nullable: true })
  name?: string;

  @Field({ nullable: true })
  description?: string;

  @Field(type => [String], { nullable: true })
  talents?: string[];
}