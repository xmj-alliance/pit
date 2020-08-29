import { getModelForClass, prop } from "@typegoose/typegoose";

export class User {

  @prop({
    required: true,
    unique: true,
    type: String,
  })
  dbname: string;

  @prop({
    type: String,
  })
  name?: string;

}

export const users = getModelForClass(User);