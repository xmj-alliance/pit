import { ObjectType, Field, ID } from "type-graphql";
import { StudiedActor } from "./studiedActor";

@ObjectType("Drama")
export class StudiedDrama {

  @Field(type => ID)
  id: string;
  
  @Field()
  dbname: string;

  @Field()
  name: string;

  @Field({ nullable: true })
  description?: string;

  @Field()
  genre: string;

  @Field(type => [StudiedActor])
  actors: StudiedActor[];

}