import { Post, Prisma, User } from "prisma/generated/prisma-client-js";
import prisma from "prisma/localPrismaClient";

import { IPipe } from "src/activities/interfaces";

const isUserCreateInput = (obj: any): obj is Prisma.UserCreateInput => {
  return obj && obj.email;
};

export interface IAddUserWithPostsPipeOutput extends User {
  posts: Post[];
}

export class AddUserWithPostsPipe implements IPipe<IAddUserWithPostsPipeOutput> {
  input: unknown;

  process = async () => {

    if (!isUserCreateInput(this.input)) {
      throw new Error("Incorrect input object type.");
    }

    return await prisma.user.create({ data: this.input, include: { posts: true } });

  };

}


