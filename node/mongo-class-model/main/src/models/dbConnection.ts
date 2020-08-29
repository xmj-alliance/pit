import { Mongoose } from "mongoose";

export interface DBConfigs {
  user: string,
  password: string,
  host: string,
  dataDB: string,
  authDB: string,
}

export interface IDBConnection {
  instance: Mongoose | null,
  connect: () => Promise<boolean>,
}