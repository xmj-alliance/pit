import { Prisma } from "prisma/generated/prisma-client-js";
import { BaseFlow } from "src/activities/baseFlow";
import { IPipe } from "src/activities/interfaces";
import { AddUserWithPostsPipe, IAddUserWithPostsPipeOutput } from "./pipes/addUserWithPosts";

export class AddInitUserFlow extends BaseFlow<IAddUserWithPostsPipeOutput> {

  pipes: IPipe<unknown>[] = [
    new AddUserWithPostsPipe(),
  ];

  /**
   *
   */
  constructor(
    input: Prisma.UserCreateInput
  ) {
    super();
    this.input = input;
  }

}