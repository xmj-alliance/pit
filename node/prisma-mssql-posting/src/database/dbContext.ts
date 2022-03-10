import { PrismaClient } from "prisma/generated/prisma-client-js";

export class DBContext {

  private readonly prisma = new PrismaClient();

  drop = async (): Promise<boolean> => {
    await this.prisma.post.deleteMany({});
    await this.prisma.user.deleteMany({});
    return true;
  }

  disconnect = async () => {
    await this.prisma.$disconnect();
  };

}