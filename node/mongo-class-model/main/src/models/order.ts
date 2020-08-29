import { getModelForClass, prop, Ref } from "@typegoose/typegoose";
import { Item } from "./item";
import { User } from "./user";

export class Order {

  @prop({
    required: true,
    ref: User,
  })
  userID: Ref<User>;

  @prop({
    required: true,
    ref: Item,
  })
  itemID: Ref<Item>;

  @prop({
    type: Date,
  })
  createDate?: Date;

  @prop({
    type: Boolean,
  })
  isComplete?: boolean;

}

export const orders = getModelForClass(Order);