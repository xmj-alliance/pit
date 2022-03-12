import { PrismaClient } from "prisma/generated/prisma-client-js";

export interface IDBContext {
  db: PrismaClient;

  drop: () => Promise<boolean>;
  disconnect: () => Promise<void>;
}