import prisma from "prisma/localPrismaClient";
import { IDBContext } from "./interfaces";

export class DBContext implements IDBContext {

  readonly db = prisma;

  drop = async (): Promise<boolean> => {
    await this.db.post.deleteMany({});
    await this.db.user.deleteMany({});
    return true;
  }

  /**
   * Disconnects DB connection. No need to explicitly call in most scenarios.
   */
  disconnect = async (): Promise<void> => {
    await this.db.$disconnect();
  };

}