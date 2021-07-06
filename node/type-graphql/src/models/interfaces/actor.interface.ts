export interface IInputActor {
  dbname: string;
  name?: string;
  description?: string;
  talents?: string[];
}

export interface IStoredActor {
  id: string,
  dbname: string,
  name: string,
  description: string,
  talents: string[],
}

export interface IActorQuerySelector {
  id?: string,
  dbname?: string,
}

export interface IActorQueryCondition {
  dbnames: string[],
}