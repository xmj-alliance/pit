import { Post, Prisma, User } from "prisma/generated/prisma-client-js";
import prisma from "prisma/localPrismaClient";
import { IPipe } from "src/pipes/interfaces";

export interface IAddUserWithPostsPipeOutput extends User {
  posts: Post[];
}

export class AddUserWithPostsPipe implements IPipe<IAddUserWithPostsPipeOutput> {
  private readonly input: Prisma.UserCreateInput;

  private readonly _task: Promise<IAddUserWithPostsPipeOutput>;
  public get task(): Promise<IAddUserWithPostsPipeOutput> {
    return this._task;
  }

  private _output: IAddUserWithPostsPipeOutput | null = null;
  public get output(): IAddUserWithPostsPipeOutput | null {
    return this._output;
  }
  private set output(v: IAddUserWithPostsPipeOutput | null) {
    this._output = v;
  }

  private action = async () => {
    this.output = await prisma.user.create({ data: this.input, include: { posts: true } });
    return this.output;
  };

  /**
   *
   */
  constructor(
    input: Prisma.UserCreateInput
  ) {
    this.input = input;
    this._task = this.action();
  }

}