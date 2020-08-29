import { getModelForClass, prop } from "@typegoose/typegoose";

export class Item {

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

  @prop({
    type: Number,
  })
  price?: number;

}

export const items = getModelForClass(Item);