import { ObjectType, Field } from "type-graphql";
import { ICUDMessage } from "./interfaces/message.interface";

@ObjectType("CUDMessage")
export class CUDMessage implements ICUDMessage {

  @Field()
  ok: boolean;

  @Field()
  numAffected: number;

  @Field()
  message: string;

}