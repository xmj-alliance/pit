export interface IInputDrama {
  dbname: string;
  name?: string;
  description?: string;
  genre: string;
  actors?: string[];
}

export interface IStoredDrama {
  id: string;
  dbname: string;
  name: string;
  description: string;
  genre: string;
  actors: string[];
}

export interface IDramaQuerySelector {
  id?: string,
  dbname?: string,
}

export interface IDramaQueryCondition {
  dbnames: string[]
}