import { ObjectType, Field, ID } from "type-graphql";
import { IStoredDrama } from "./interfaces/drama.interface";
import { StoredActor } from "./storedActor";

@ObjectType("Drama")
export class StoredDrama implements IStoredDrama {

  @Field(type => ID)
  id: string;
  
  @Field()
  dbname: string;

  @Field(type => String, { nullable: true })
  name?: string | null;

  @Field(type => String, { nullable: true })
  description?: string | null;

  @Field(type => String)
  genre: string;

  @Field(type => [StoredActor], { nullable: true })
  actors?: string[] | null;

}