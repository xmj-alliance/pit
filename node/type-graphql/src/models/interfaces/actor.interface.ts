export interface IInputActor {
  dbname: string;
  name?: string | null;
  description?: string | null;
  talents?: string[] | null;
}

export interface IStoredActor {
  id: string,
  dbname: string,
  name?: string | null,
  description?: string | null,
  talents?: string[] | null,
}

export interface IActorQuerySelector {
  id?: string,
  dbname?: string,
}

export interface IActorQueryCondition {
  dbnames: string[],
}