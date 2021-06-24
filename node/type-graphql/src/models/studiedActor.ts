import { ObjectType, Field, ID } from "type-graphql";

@ObjectType("Actor")
export class StudiedActor {

  @Field(type => ID)
  id: string;
  
  @Field()
  dbname: string;

  @Field()
  name: string;

  @Field({ nullable: true })
  description?: string;

  @Field(type => [String])
  talents: string[];
}