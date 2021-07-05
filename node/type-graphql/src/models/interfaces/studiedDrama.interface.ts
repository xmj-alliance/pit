import { IStudiedActor } from "./studiedActor.interface";

export interface IStudiedDrama {
  id: string;
  dbname: string;
  name?: string;
  description?: string;
  genre?: string;
  actors?: IStudiedActor[];
}