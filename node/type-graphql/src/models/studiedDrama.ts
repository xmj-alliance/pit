import { ObjectType, Field, ID } from "type-graphql";
import { IStudiedDrama } from "./interfaces/studiedDrama.interface";
import { StudiedActor } from "./studiedActor";

@ObjectType("Drama")
export class StudiedDrama implements IStudiedDrama {

  @Field(type => ID)
  id: string;
  
  @Field()
  dbname: string;

  @Field({ nullable: true })
  name?: string;

  @Field({ nullable: true })
  description?: string;

  @Field({ nullable: true })
  genre?: string;

  @Field(type => [StudiedActor], { nullable: true })
  actors?: StudiedActor[];

}